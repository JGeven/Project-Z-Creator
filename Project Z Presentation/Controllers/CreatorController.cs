using Microsoft.AspNetCore.Mvc;
using Project_Z_Database;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using Project_Z_Presentation.Models;

namespace Project_Z_Presentation.Controllers
{
    public class CreatorController : Controller
    {
         private CharacterContainer _characterContainer = new CharacterContainer(new CharacterSql());
         private OccupationContainer _occupationContainer = new OccupationContainer(new OccupationSql());
         private TraitsContainer _traitsContainer = new TraitsContainer(new TraitsSql());

         public bool LoggedIn()
         {
             if (HttpContext.Session.GetString("userID") != null)
             {
                 return true;
             }
             return false;
         }
         
         [HttpGet]
         public IActionResult Index()
         {
             if (!LoggedIn())
             {
                 return RedirectToAction("Login", "User");
             }
             
             int userID = (int)HttpContext.Session.GetInt32("userID");

             List<Character> characters = _characterContainer.GetCharacterbyUserID(userID);
             List<CharacterViewModel> characterViewModels = new List<CharacterViewModel>();

             foreach (Character character in characters)
             {
                 List<TraitViewModel> traitViewModels = new List<TraitViewModel>();
                 
                 foreach (TraitDto trait in character.Traits)
                 {
                     traitViewModels.Add(new TraitViewModel
                     {
                         TraitID = trait.TraitID,
                         Name = trait.Name,
                         Cost = trait.Cost,
                     });
                 }
            
                 OccupationViewModel occupationViewModel = new OccupationViewModel
                 {
                     OccupationID = character.Occupation.OccupationID,
                     Name = character.Occupation.Name,
                     Cost = character.Occupation.Cost,
                 };
                
                 CharacterViewModel characterViewModel = new CharacterViewModel
                 {
                     CharacterID = character.CharacterID,
                     Name = character.Name,
                     Cost = character.Cost,
                     Occupation = occupationViewModel,
                     Traits = traitViewModels,
                 };
                 
                 characterViewModels.Add(characterViewModel);
             }
             return View(characterViewModels);
         }
         
         [HttpGet] 
         public IActionResult Create()
         {
             if (!LoggedIn())
             {
                 return RedirectToAction("Login", "User");
             }
             
             ViewBag.Occupation = GetOccupation();
             ViewBag.Trait = GetTrait();

             return View();
         }
        
         [HttpPost] 
         public IActionResult Create(CharacterViewModel characterViewModel)
         {
             if (!LoggedIn())
             {
                 return RedirectToAction("Login", "User");
             }
             
             int userID = (int)HttpContext.Session.GetInt32("userID");
             
             Character character = new Character(characterViewModel.Name, characterViewModel.Cost, characterViewModel.Occupation.OccupationID, characterViewModel.Arraytraits, userID);
             _characterContainer.SaveCharacter(character);
             
             ViewBag.Occupation = GetOccupation();
             ViewBag.Trait = GetTrait();
             return RedirectToAction("Index", "Creator");
         }

         
         //These Methods are for filling the ViewBags
         public List<OccupationViewModel> GetOccupation()
        {
            List<OccupationViewModel> occupationViewModels = new List<OccupationViewModel>();
            List<Occupations> occupationsList = _occupationContainer.GetOccupations();
            foreach (Occupations occupations in occupationsList)
            {
                OccupationViewModel viewModel = new OccupationViewModel(occupations);
                occupationViewModels.Add(viewModel);
            }
            return occupationViewModels;
        }

        public List<TraitViewModel> GetTrait()
        {
            List<TraitViewModel> traitViewModels = new List<TraitViewModel>();
            List<Trait> traits = _traitsContainer.GetTraits();
            foreach (Trait trait in traits)
            {
                TraitViewModel viewModel = new TraitViewModel(trait);
                traitViewModels.Add(viewModel);
            }
            return traitViewModels;
        }
    }
}
