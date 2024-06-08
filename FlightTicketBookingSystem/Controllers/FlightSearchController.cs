using FlightTicketBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FlightTicketBookingSystem.Controllers
{
   
    public class FlightSearchController : Controller
    {
        ContextCS db = new ContextCS();

        // GET: FlightSearch
        public ActionResult Index()
         {
             ViewBag.dCity = db.TicketReserve_tbls.Select(l => l.Resfrom).Distinct().ToList();
             ViewBag.aCity = db.TicketReserve_tbls.Select(l => l.ResTo).Distinct().ToList();
           

             return View();
         }

        [Authorize]
        [HttpPost]
        public ActionResult searchFlight(string cityto, string cityfrom, string date1)
        {
            var c = db.TicketReserve_tbls.Where(l => l.ResTo.Equals(cityto) && l.Resfrom.Equals(cityfrom) && l.ResDepDate.Equals(date1));
            ViewBag.ss = c;
            //TempData["toCustomer"] = c;
            /*return View("searchFlight1");*/
            Session["message"] = "Date experied";
            return View();
        }
        [Authorize]
        public ActionResult searchFlightDetails()
        {
            return View();
        }



       
    }
}