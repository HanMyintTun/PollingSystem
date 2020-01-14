using LALCO_PollingSystem.Models;
using LALCO_PollingSystem.Repository.Interfaces;
using LALCO_PollingSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LALCO_PollingSystem.Repository;
namespace LALCO_PollingSystem.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController()
        {
            _userService = new UserService(new UserRepository());
        }

        public HomeController(IUserService userService)
        {
            _userService = userService;

        }

        //User Registration Page
        public ActionResult Register()
        {
            return View();
        }

        //User Registration Action
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!_userService.CreateUser(user))
            {
                ViewBag.Msg = "Username already exist. Please choose different name.";
                return View();
            }else
            {
                ViewBag.Msg = "Registration Completed. Please Login to the system";
                ModelState.Clear();
                return View();
            }
           
        }

        //Login Page
        public ActionResult Login()
        {
            return View();
        }
        
        //Login Action
        [HttpPost]
        public ActionResult Login(User user)
        {
            User usr = new User();
            usr = _userService.Login(user);
            User LoggedInUser = null;

            if (usr != null)
            {
                //store user object in session
                Session["LoggedInUser"] = usr;
                LoggedInUser = (User) Session["LoggedInUser"];           
            }
            else
            {
                ViewBag.Error = "User name or password is incorrect";
                return View();
            }
                   
            return RedirectToAction("Index");
        }
       
        public ActionResult Logout()
        {
           // FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index");
        }
        //Home page
        public ActionResult Index()
        {
            return View();
        }

      
    }
}