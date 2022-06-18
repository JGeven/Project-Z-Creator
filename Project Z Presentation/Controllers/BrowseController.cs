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
        private TraitsContainer _traitsContainer = new TraitsContainer(new TraitsSql());
        private OccupationContainer _occupationContainer = new OccupationContainer(new OccupationSql());
        private ReviewContainer _reviewContainer = new ReviewContainer(new ReviewSql());
        
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
            List<ReviewViewModel> reviewViewModels = new List<ReviewViewModel>();

            foreach (ReviewDTO review in character.Reviews)
            {
                reviewViewModels.Add(new ReviewViewModel
                {
                    ReviewID = review.ReviewID,
                    UserName = review.UserName,
                    UserID = review.UserID,
                    Comment = review.Comment,
                    Rating = review.Rating,
                });
            }
            
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
                Reviews = reviewViewModels,
            };
            
            ViewBag.Occupation = GetOccupation();
            ViewBag.Trait = GetTrait();
            return View(characterViewModel);
        }

        [HttpGet] 
        public IActionResult Comment(int characterID)
        {
            ReviewViewModel reviewViewModel = new ReviewViewModel();
            reviewViewModel.CharacterID = characterID;
            return View(reviewViewModel);
        }

        [HttpPost]
        public IActionResult CreateComment(ReviewViewModel reviewViewModel, int characterID)
        {
            if (!LoggedIn())
            {
                return RedirectToAction("Login", "User");
            }
            
            int userID = (int)HttpContext.Session.GetInt32("userID");

            Review review = new Review(reviewViewModel.Rating, reviewViewModel.Comment);
            _reviewContainer.CreateReview(review, characterID, userID);

            return RedirectToAction("Index", "Browse");
        }

        [HttpGet] public IActionResult Review(int reviewID)
        {
            if (!LoggedIn())
            {
                return RedirectToAction("Login", "User");
            }

            Review review = _reviewContainer.GetReviewbyID(reviewID);

            ReviewViewModel reviewViewModel = new ReviewViewModel()
            {
                ReviewID = review.ReviewID,
                Comment = review.Comment,
                Rating = review.Rating,
            };

            return View(reviewViewModel);
        }

        public IActionResult DeleteReview(int reviewID)
        {
            if (!LoggedIn())
            {
                return RedirectToAction("Login", "User");
            }

            _reviewContainer.DeleteReview(reviewID);

            return RedirectToAction("Index", "Browse");
        }

        public IActionResult UpdateReview(ReviewViewModel reviewViewModel, int reviewID)
        {
            if (!LoggedIn())
            {
                return RedirectToAction("Login", "User");
            }

            reviewViewModel.ReviewID = reviewID;
            
            Review review = new Review(reviewViewModel.ReviewID, reviewViewModel.Rating, reviewViewModel.Comment);
            _reviewContainer.UpdateReview(review);

            return RedirectToAction("Index", "Browse");
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
