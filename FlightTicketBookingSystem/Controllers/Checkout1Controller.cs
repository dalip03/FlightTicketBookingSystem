using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FlightTicketBookingSystem.Models;

namespace FlightTicketBookingSystem.Controllers
{
    [Authorize]
    public class Checkout1Controller : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: Checkout1
        public ActionResult Index()
        {
            return View(db.bookingDetailsDatas.ToList());
        }


        
        // GET: Checkout1/Details/5
        /*public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingDetailsData bookingDetailsData = db.bookingDetailsDatas.Find(id);
            if (bookingDetailsData == null)
            {
                return HttpNotFound();
            }
            return View(bookingDetailsData);
        }*/

        
        public ActionResult Details()
        {
            var id = Session["id"] as int?;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingDetailsData bookingDetailsData = db.bookingDetailsDatas.Find(id);
            if (bookingDetailsData == null)
            {
                return HttpNotFound();
            }
            return View(bookingDetailsData);
        }

        // GET: Checkout1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingDetailsData bookingDetailsData = db.bookingDetailsDatas.Find(id);
            if (bookingDetailsData == null)
            {
                return HttpNotFound();
            }
            return View(bookingDetailsData);
        }

        // POST: Checkout1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,FirstName,LastName,bCusPhoneNum,AdharNumber,ResTicketPrice,Resfrom,ResTo")] BookingDetailsData bookingDetailsData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingDetailsData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingDetailsData);
        }

        // GET: Checkout1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingDetailsData bookingDetailsData = db.bookingDetailsDatas.Find(id);
            if (bookingDetailsData == null)
            {
                return HttpNotFound();
            }
            return View(bookingDetailsData);
        }

        // POST: Checkout1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingDetailsData bookingDetailsData = db.bookingDetailsDatas.Find(id);
            db.bookingDetailsDatas.Remove(bookingDetailsData);
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
