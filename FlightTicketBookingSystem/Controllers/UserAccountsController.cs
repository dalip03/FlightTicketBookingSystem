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
    
    public class UserAccountsController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: UserAccounts
        [Authorize(Roles = "Dalip01")]
        public ActionResult Index()
        {
            return View(db.userAccounts.ToList());
        }

        // GET: UserAccounts/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.userAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Create
        [Authorize(Roles = "Dalip01")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Dalip01")]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,Email,UserName,Password,Age,Phoneno,AdharNumber")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.userAccounts.Add(userAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccount);
        }

        // GET: UserAccounts/Edit/5
        [Authorize(Roles = "Dalip01")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.userAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Dalip01")]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,Email,UserName,Password,Age,Phoneno,AdharNumber")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        [Authorize(Roles = "Dalip01")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.userAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Dalip01")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAccount userAccount = db.userAccounts.Find(id);
            db.userAccounts.Remove(userAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Dalip01")]
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
