using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Project_Z_Presentation.Models;
using Project_Z_Database;
using Project_Z_Logic;

namespace Project_Z_Presentation.Controllers
{
    public class CreatorController : Controller
    {
         private CharacterContainer _characterContainer = new CharacterContainer(new CharacterSql());
         private OccupationContainer _occupationContainer = new OccupationContainer(new OccupationSQL());
         private TraitsContainer _traitsContainer = new TraitsContainer(new TraitsSQL());
         
         [HttpGet]
         public IActionResult Index()
         {
             dynamic model = new ExpandoObject();
             model.Characters = GetCharacter();
             return View(model);
         }
         
         [HttpGet]
         public IActionResult Create()
         {
             dynamic model = new ExpandoObject();
             model.Occupations = GetOccupation();
             model.Traits = GetTrait();

             return View(model);
         }


         
         
         // [HttpGet] public IActionResult Create(int characterID)
         // {
         //     dynamic model = new ExpandoObject();
         //     model.Detail = Detail(characterID);
         //
         //     return View(model);
         // }
         
         [HttpPost] 
         public IActionResult Create(CharacterViewModel characterViewModel)
         {
             Character character = new Character(characterViewModel.Name, characterViewModel.Cost, characterViewModel.Occupation);
             _characterContainer.SaveCharacter(character);
             
             return View();
         }

         
         [HttpDelete] 
         public IActionResult Index(CharacterViewModel characterViewModel)
         {
             Character character = new Character(characterViewModel.CharacterID);
             _characterContainer.DeleteCharacter(character.CharacterID);

             return View();
         }
        
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

        public List<CharacterViewModel> GetCharacter()
        {
            List<CharacterViewModel> characterViewModels = new List<CharacterViewModel>();
            List<Character> characters = _characterContainer.GetCharacters();
            foreach (Character character in characters)
            {
                CharacterViewModel viewModel = new CharacterViewModel(character);
                characterViewModels.Add(viewModel);
            }
            return characterViewModels;
        }

        public CharacterViewModel Detail(int characterID)
        {
            CharacterViewModel characterViewModel = new CharacterViewModel();
            List<Character> characters = _characterContainer.GetCharacters();
            foreach (Character character in characters)
            {
                if (character.CharacterID == characterID)
                {
                    CharacterViewModel viewModel = new CharacterViewModel(character);
                    characterViewModel = viewModel;
                }
            }
            return characterViewModel;
        }

    }
}
