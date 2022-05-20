using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Project_Z_Database;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using Project_Z_Presentation.Models;

namespace Project_Z_Presentation.Controllers
{
    public class BrowseController : Controller
    {
        private CharacterContainer _characterContainer = new CharacterContainer(new CharacterSql());
        
        public IActionResult Index()
        {
            List<CharacterViewModel> characterViewModel = GetCharacter();

            return View(characterViewModel);
        }
        
        public IActionResult Detail(int characterID)
        {
            Character character = _characterContainer.GetCharacterbyID(characterID);
            CharacterViewModel characterViewModel = new CharacterViewModel()
            {
                CharacterID = character.CharacterID,
                Name = character.Name,
                Cost = character.Cost,
                Occupation = character.Occupation,

            };
            return View(characterViewModel);
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
        
        public IActionResult DeleteCharacter(int characterID)
        {
            _characterContainer.DeleteCharacter(characterID);

                return RedirectToAction("Index","Browse");
        }
    }
}
