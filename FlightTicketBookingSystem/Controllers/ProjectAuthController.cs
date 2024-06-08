using FlightTicketBookingSystem.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FlightTicketBookingSystem.Controllers
{
    [AllowAnonymous]
    public class ProjectAuthController : Controller
    {

        // GET: ProjectAuth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount model)
        {
            using (var context = new ContextCS())
            {
                bool isValid = context.userAccounts.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if (isValid)
                {    
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "FlightSearch");
                }
                ModelState.AddModelError("", "Invalid UserName and Password");
                return View();
            }

        }

        public ActionResult Signup()
        {

            return View();
        }

        [HttpPost]
        [HandleError]
        public ActionResult Signup(UserAccount model)
        {
            using (var context = new ContextCS())
            {
                if (context.userAccounts.Any(u => u.UserName == model.UserName))
                {
                    ModelState.AddModelError("UserName","Username already exists. Please choose a different one.");
                    return View(model); // Return to signup view with validation error
                }
                context.userAccounts.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}