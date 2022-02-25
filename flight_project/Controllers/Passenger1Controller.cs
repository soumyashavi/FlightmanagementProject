using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using flight_project.Models;

namespace flight_project.Controllers
{
    public class Passenger1Controller : Controller
    {
        private FlightEntities4 db = new FlightEntities4();

        // GET: Passenger1
        public ActionResult Index()
        {
            return View(db.Passenger1.ToList());
        }

        // GET: Passenger1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger1 passenger1 = db.Passenger1.Find(id);
            if (passenger1 == null)
            {
                return HttpNotFound();
            }
            return View(passenger1);
        }

        // GET: Passenger1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passenger1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PassengerId,PassengerAge,PassengerCount,PassengerUIN,Luggages")] Passenger1 passenger1)
        {
            if (ModelState.IsValid)
            {
                db.Passenger1.Add(passenger1);
                db.SaveChanges();
                return RedirectToAction("Create", "Booking2");
            }

            return View(passenger1);
        }

        // GET: Passenger1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger1 passenger1 = db.Passenger1.Find(id);
            if (passenger1 == null)
            {
                return HttpNotFound();
            }
            return View(passenger1);
        }

        // POST: Passenger1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PassengerId,PassengerAge,PassengerCount,PassengerUIN,Luggages")] Passenger1 passenger1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passenger1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passenger1);
        }

        // GET: Passenger1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger1 passenger1 = db.Passenger1.Find(id);
            if (passenger1 == null)
            {
                return HttpNotFound();
            }
            return View(passenger1);
        }

        // POST: Passenger1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Passenger1 passenger1 = db.Passenger1.Find(id);
            db.Passenger1.Remove(passenger1);
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
