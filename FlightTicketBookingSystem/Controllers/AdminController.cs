using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightTicketBookingSystem.Models;

namespace FlightTicketBookingSystem.Controllers
{
    [Authorize(Roles = "Dalip01")]
    public class AdminController : Controller
    {
        ContextCS c = new ContextCS();
        // GET: Admin
        public ActionResult Index()
        {
            
                return View();
            
        }

        [HttpGet]
        public ActionResult Adminlogin() 
        {
            
                return View();

        }

        [HttpPost]
        public ActionResult Adminlogin(AdminLogin l)
        {
            var x = c.AdminLogins.Where(a => a.AdName == l.AdName && a.Password == l.Password).FirstOrDefault();
            if (x != null) 
            {
             
                return RedirectToAction("Deshboard");
            }
            else
            {
                ViewBag.m = "Wrong user id or password";
                return View();
            }
            
        }

        public ActionResult Deshboard()
        {
           return View();   
        }
    }
}