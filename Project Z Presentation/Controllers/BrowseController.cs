﻿using Microsoft.AspNetCore.Mvc;
using Project_Z_Database;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using Project_Z_Presentation.Models;

namespace Project_Z_Presentation.Controllers
{
    public class BrowseController : Controller
    {
        private CharacterContainer _characterContainer = new CharacterContainer(new CharacterSql());
        private TraitsContainer _traitsContainer = new TraitsContainer(new TraitsSql());
        private OccupationContainer _occupationContainer = new OccupationContainer(new OccupationSql());
        
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
            
            List<CharacterViewModel> characterViewModels = new List<CharacterViewModel>();
            foreach (Character character in _characterContainer.GetCharacters())
            {
                List<TraitViewModel> traitViewModels = new List<TraitViewModel>();
                foreach (var trait in character.Traits)
                {
                    traitViewModels.Add(new TraitViewModel
                    {
                        TraitID = trait.TraitID,
                        Name = trait.Name,
                        Cost = trait.Cost,
                        PosNeg = trait.PosNeg
                    });
                }

                OccupationViewModel occupationViewModel = new OccupationViewModel
                {
                    OccupationID = character.Occupation.OccupationID,
                    Name = character.Occupation.Name,
                    Cost = character.Occupation.Cost,
                };
                CharacterViewModel characterView = new CharacterViewModel
                {
                    CharacterID = character.CharacterID,
                    Name = character.Name,
                    Cost = character.Cost,
                    Occupation = occupationViewModel,
                    Traits = traitViewModels
                };
                characterViewModels.Add(characterView);
            }
            return View(characterViewModels);
            
        }
        
        [HttpGet]
        public IActionResult Detail(int characterID)
        {
            if (!LoggedIn())
            {
                 return RedirectToAction("Login", "User");
            }
            
            Character character = _characterContainer.GetCharacterbyID(characterID);
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

            UserViewModel userViewModel = new UserViewModel()
            {
                UserID = character.User.UserID,
            };
            
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
                User = userViewModel,
                Occupation = occupationViewModel,
                Traits = traitViewModels,
            };
            
            ViewBag.Occupation = GetOccupation();
            ViewBag.Trait = GetTrait();
            return View(characterViewModel);
        }

        public IActionResult DeleteCharacter(int characterID)
        {
            if (!LoggedIn())
            {
                return RedirectToAction("Login", "User");
            }
            
            _characterContainer.DeleteCharacter(characterID);

            return RedirectToAction("Index","Browse");
        }
        
        public IActionResult UpdateCharacter(CharacterViewModel characterViewModel, int characterID)
        {
            if (!LoggedIn())
            {
                return RedirectToAction("Login", "User");
            }
            
            int userID = (int)HttpContext.Session.GetInt32("userID");
            
            Character character = new Character(characterViewModel.CharacterID, characterViewModel.Name, characterViewModel.Cost, characterViewModel.OccupationID, characterViewModel.Arraytraits, userID);
            _characterContainer.UpdateCharacter(character);

            return RedirectToAction("Index", "Browse");
        }
        
        //These methods are for filling the ViewBags
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
    }
}
