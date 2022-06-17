using Microsoft.AspNetCore.Mvc;
using Project_Z_Database;
using Project_Z_Logic;
using Project_Z_Presentation.Models;

namespace Project_Z_Presentation.Controllers
{
    public class UserController : Controller
    {
        private UserContainer _userContainer = new UserContainer(new UserSql());

        public bool LoggedIn()
        {
            if (HttpContext.Session.GetString("userID") != null)
            {
                return true;
            }
            return false;
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
            UserViewModel userViewModel = new UserViewModel
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
            return RedirectToAction("Index", "Browse");
        }

        [HttpPost] 
        public IActionResult Login(UserViewModel userViewModel)
        {
            if (HttpContext.Session.GetString("userID") == null)
            {
                User user = _userContainer.Login(userViewModel.Email, userViewModel.Password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("userID", user.UserID);
                    HttpContext.Session.SetString("name", user.Name);
                    HttpContext.Session.SetString("email", user.Email);

                    return RedirectToAction("Index", "Home");
                }
                RedirectToAction("Login", "User");
                
                
            }
            return RedirectToAction("Login","User");

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
                return RedirectToAction("Login", "User");
            }

            return RedirectToAction("Register", "User");
        }

        public IActionResult DeleteUser(int userID)
        {
            try
            {
                _userContainer.DeleteUser(userID);
                
                if (HttpContext.Session.GetInt32("userID") == userID)
                {
                    LogOut();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RedirectToAction("Index", "Home");
        }
        

        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}