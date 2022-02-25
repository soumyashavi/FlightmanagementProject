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
    public class Booking2Controller : Controller
    {
        private FlightEntities5 db = new FlightEntities5();

        // GET: Booking2
        public ActionResult Index()
        {
            var booking2 = db.Booking2.Include(b => b.airport1).Include(b => b.airport11).Include(b => b.Registration).Include(b => b.scheduleflight2).Include(b => b.Passenger1);
            return View(booking2.ToList());
        }

        public ActionResult welcome_Here(int  id)
        {


            var model = db.Booking2.Where(x => x.BookingId == id).ToList();
            return View(model);
        }

        // GET: Booking2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking2 booking2 = db.Booking2.Find(id);
            if (booking2 == null)
            {
                return HttpNotFound();
            }
            return View(booking2);
        }

        // GET: Booking2/Create
        public ActionResult Create()
        {
            ViewBag.Destination = new SelectList(db.airport1, "AirportLocation", "AirportLocation");
            ViewBag.Source = new SelectList(db.airport1, "AirportLocation", "AirportLocation");
            ViewBag.ConfirmId = new SelectList(db.Registrations, "UserId", "UserId");
            ViewBag.FlightId = new SelectList(db.scheduleflight2, "ScduleId", "ScduleId");
            ViewBag.UserId = new SelectList(db.Passenger1, "PassengerId", "PassengerId");
            return View();
        }

        // POST: Booking2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,UserId,FlightId,Source,Destination,ConfirmId")] Booking2 booking2)
        {
            if (ModelState.IsValid)
            {
                db.Booking2.Add(booking2);
                db.SaveChanges();
                return RedirectToAction("welcome_Here");
            }

            ViewBag.Destination = new SelectList(db.airport1, "AirportLocation", "AirportLocation", booking2.Destination);
            ViewBag.Source = new SelectList(db.airport1, "AirportLocation", "AirportLocation", booking2.Source);
            ViewBag.ConfirmId = new SelectList(db.Registrations, "UserId", "UserId", booking2.ConfirmId);
            ViewBag.FlightId = new SelectList(db.scheduleflight2, "ScduleId", "ScduleId", booking2.FlightId);
            ViewBag.UserId = new SelectList(db.Passenger1, "PassengerId", "PassengerId", booking2.UserId);
            return View(booking2);
        }

        // GET: Booking2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking2 booking2 = db.Booking2.Find(id);
            if (booking2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Destination = new SelectList(db.airport1, "AirportLocation", "AirportLocation", booking2.Destination);
            ViewBag.Source = new SelectList(db.airport1, "AirportLocation", "AirportLocation", booking2.Source);
            ViewBag.ConfirmId = new SelectList(db.Registrations, "UserId", "UserId", booking2.ConfirmId);
            ViewBag.FlightId = new SelectList(db.scheduleflight2, "ScduleId", "ScduleId", booking2.FlightId);
            ViewBag.UserId = new SelectList(db.Passenger1, "PassengerId", "PassengerId", booking2.UserId);
            return View(booking2);
        }

        // POST: Booking2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,UserId,FlightId,Source,Destination,ConfirmId")] Booking2 booking2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Destination = new SelectList(db.airport1, "AirportLocation", "AirportLocation", booking2.Destination);
            ViewBag.Source = new SelectList(db.airport1, "AirportLocation", "AirportLocation", booking2.Source);
            ViewBag.ConfirmId = new SelectList(db.Registrations, "UserId", "UserId", booking2.ConfirmId);
            ViewBag.FlightId = new SelectList(db.scheduleflight2, "ScduleId", "ScduleId", booking2.FlightId);
            ViewBag.UserId = new SelectList(db.Passenger1, "PassengerId", "PassengerId", booking2.UserId);
            return View(booking2);
        }

        // GET: Booking2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking2 booking2 = db.Booking2.Find(id);
            if (booking2 == null)
            {
                return HttpNotFound();
            }
            return View(booking2);
        }

        // POST: Booking2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking2 booking2 = db.Booking2.Find(id);
            db.Booking2.Remove(booking2);
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
        public ActionResult Welcome()
        {
            return View();
        }
        [HttpPost]
        public ActionResult welcome(Booking2 bk)
        {
            using (FlightEntities5 db = new FlightEntities5())
            // using (FlightEntities11 db = new FlightEntities11())
            {
                db.Booking2.Add(bk);
                db.SaveChanges();
                int id = bk.BookingId;


                ViewBag.id = id;

            }

            return View();
        }
        public ActionResult Search(int? search)
        {
            var model = db.Booking2.Where(x => x.BookingId == search).ToList();
            return View(model);

        }

        //public ActionResult welocme_Here()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult welcome_Here(scheduleflight2 bk)
        //{
        //    using (FlightEntities3 db = new FlightEntities3())

        //    {
        //        db.scheduleflight2.Add(bk);
        //        db.SaveChanges();

        //        //  string name = bk.UserName;
               
        //        int amount =Convert.ToInt32(bk.TotalCost);

        //        ViewBag.amount = amount;
        //       // ViewBag.Id = id;
        //       // ViewBag.Name = name;
        //    }

        //    return View();
        //}
    }
}
