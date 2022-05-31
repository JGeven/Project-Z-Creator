using Microsoft.AspNetCore.Mvc;
using Project_Z_Database;
using Project_Z_Logic;
using Project_Z_Presentation.Models;

namespace Project_Z_Presentation.Controllers
{
    public class UserController : Controller
    {
        private UserContainer _userContainer = new UserContainer(new UserSQL());

        public bool LoggedIn()
        {
            if (HttpContext.Session.GetString("userID") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public IActionResult Detail()
        {
            int userID = (int)HttpContext.Session.GetInt32("userID");
            if (!LoggedIn())
            {
                return RedirectToAction("Login", "User");
            }

            User user = _userContainer.GetUserbyID(userID);
            UserViewModel userViewModel = new UserViewModel()
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };

            return View(userViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("userID") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Browse");
            }
        }

        [HttpPost] 
        public IActionResult Login(UserViewModel userViewModel)
        {
            if (HttpContext.Session.GetString("userID") == null)
            {
                User user = _userContainer.Login(userViewModel.Email, userViewModel.Password);
                
                HttpContext.Session.SetInt32("userID", user.UserID);
                HttpContext.Session.SetString("name", user.Name);
                HttpContext.Session.SetString("email", user.Email);

                ViewData["Message"] = "Login Succesfull!";
                ViewData["MessageClass"] = "alert-succes";

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Login","User");
            }
            
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel userViewModel)
        {
            User user = new User(userViewModel.Name, userViewModel.Email, userViewModel.Password);
            if (_userContainer.RegisterUser(user))
            {
                
            }

            return RedirectToAction("Login", "User");
        }
        

        // GET
        public IActionResult Index()
        {
            return View();
        }


    }
}
