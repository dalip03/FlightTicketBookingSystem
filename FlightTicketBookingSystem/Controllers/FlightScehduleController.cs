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
    
    public class FlightScehduleController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: FlightScehdule
        [Authorize(Roles = "Dalip01")]
        public ActionResult Index()
        {
            var ticketReserve_tbls = db.TicketReserve_tbls.Include(t => t.Plane_tbls);
            return View(ticketReserve_tbls.ToList());
        }

        // GET: FlightScehdule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReserve_tbl ticketReserve_tbl = db.TicketReserve_tbls.Find(id);
            if (ticketReserve_tbl == null)
            {
                return HttpNotFound();
            }
            return View(ticketReserve_tbl);
        }

        // GET: FlightScehdule/Create
        [Authorize(Roles = "Dalip01")]
        public ActionResult Create()
        {
            ViewBag.PlaneId = new SelectList(db.aeroPlaneInfos, "Planeid", "APlaneName");
            return View();
        }

        // POST: FlightScehdule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Dalip01")]
        public ActionResult Create([Bind(Include = "ResId,Resfrom,ResTo,ResDepDate,ResTime,PlaneId,PlaneSeat,ResTicketPrice,ResTicketType")] TicketReserve_tbl ticketReserve_tbl)
        {
            if (ModelState.IsValid)
            {
                db.TicketReserve_tbls.Add(ticketReserve_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaneId = new SelectList(db.aeroPlaneInfos, "Planeid", "APlaneName", ticketReserve_tbl.PlaneId);
            return View(ticketReserve_tbl);
        }
        [Authorize(Roles = "Dalip01")]
        // GET: FlightScehdule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReserve_tbl ticketReserve_tbl = db.TicketReserve_tbls.Find(id);
            if (ticketReserve_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaneId = new SelectList(db.aeroPlaneInfos, "Planeid", "APlaneName", ticketReserve_tbl.PlaneId);
            return View(ticketReserve_tbl);
        }

        // POST: FlightScehdule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Dalip01")]
        public ActionResult Edit([Bind(Include = "ResId,Resfrom,ResTo,ResDepDate,ResTime,PlaneId,PlaneSeat,ResTicketPrice,ResTicketType")] TicketReserve_tbl ticketReserve_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketReserve_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaneId = new SelectList(db.aeroPlaneInfos, "Planeid", "APlaneName", ticketReserve_tbl.PlaneId);
            return View(ticketReserve_tbl);
        }

        // GET: FlightScehdule/Delete/5
        [Authorize(Roles = "Dalip01")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReserve_tbl ticketReserve_tbl = db.TicketReserve_tbls.Find(id);
            if (ticketReserve_tbl == null)
            {
                return HttpNotFound();
            }
            return View(ticketReserve_tbl);
        }

        // POST: FlightScehdule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Dalip01")]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketReserve_tbl ticketReserve_tbl = db.TicketReserve_tbls.Find(id);
            db.TicketReserve_tbls.Remove(ticketReserve_tbl);
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
