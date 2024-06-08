using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlightTicketBookingSystem.Models;

namespace FlightTicketBookingSystem.Controllers
{
    [Authorize]
    public class CustomersBookingDetailsController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: CustomersBookingDetails
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.TicketReservation);
            return View(customers.ToList());
        }

        // GET: CustomersBookingDetails/Details/5
        
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: CustomersBookingDetails/Create
        
        /*chage here*/
        public ActionResult Create()
        {         
            //ViewBag.ResId = new SelectList(db.TicketReserve_tbls, "ResId", "ResId");
            
            return View();


        }






        // POST: CustomersBookingDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] //,ResId
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,bCusPhoneNum,AdharNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
          
                db.Customers.Add(customer);
                db.SaveChanges();

             
                BookingDetailsData oBD = new BookingDetailsData();
          
                oBD.CustomerId = customer.CustomerId;
                oBD.FirstName = customer.FirstName;
                oBD.LastName = customer.LastName;
                oBD.bCusPhoneNum = customer.bCusPhoneNum;
                oBD.AdharNumber = customer.AdharNumber;
                
                /*oBD.TicketReserve_tbls = customer.TicketReservation;*/

                oBD.ResTicketPrice = (float)Session["bookingPrice"];
                oBD.Resfrom = (string)Session["Resfrom"];
                oBD.ResTo = (string)Session["ResTo"];
                //new
                oBD.Time = (string)Session["ResTime"];
                oBD.Date = (string)Session["Date"];
                db.bookingDetailsDatas.Add(oBD);
                db.SaveChanges();

                Session["id"] = oBD.Id;

                return RedirectToAction("Details", "Checkout1");
            }

            

    
            return View(customer);
        }




        // GET: CustomersBookingDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            //ViewBag.ResId = new SelectList(db.TicketReserve_tbls, "ResId", "ResId", customer.ResId);
          
            return View(customer);
        }

        // POST: CustomersBookingDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for  //,ResId
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,bCusPhoneNum,AdharNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.ResId = new SelectList(db.TicketReserve_tbls, "ResId", "ResId", customer.ResId);

            return View(customer);
        }

        // GET: CustomersBookingDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: CustomersBookingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
