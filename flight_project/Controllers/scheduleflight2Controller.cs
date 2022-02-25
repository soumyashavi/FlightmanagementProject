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
    public class scheduleflight2Controller : Controller
    {
        private FlightEntities3 db = new FlightEntities3();

        // GET: scheduleflight2
        public ActionResult Index()
        {
            var scheduleflight2 = db.scheduleflight2.Include(s => s.airport1).Include(s => s.airport11);
            return View(scheduleflight2.ToList());
        }

        // GET: scheduleflight2/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scheduleflight2 scheduleflight2 = db.scheduleflight2.Find(id);
            if (scheduleflight2 == null)
            {
                return HttpNotFound();
            }
            return View(scheduleflight2);
        }

        // GET: scheduleflight2/Create
        public ActionResult Create()
        {
            ViewBag.DestinationAirport = new SelectList(db.airport1, "AirportLocation", "AirportLocation");
            ViewBag.SourceAirport = new SelectList(db.airport1, "AirportLocation", "AirportLocation");
            return View();
        }

        // POST: scheduleflight2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScduleId,SourceAirport,DestinationAirport,DepartureTime,ArrivalTime,TotalCost")] scheduleflight2 scheduleflight2)
        {
            if (ModelState.IsValid)
            {
                db.scheduleflight2.Add(scheduleflight2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DestinationAirport = new SelectList(db.airport1, "AirportLocation", "AirportLocation", scheduleflight2.DestinationAirport);
            ViewBag.SourceAirport = new SelectList(db.airport1, "AirportLocation", "AirportLocation", scheduleflight2.SourceAirport);
            return View(scheduleflight2);
        }

        // GET: scheduleflight2/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scheduleflight2 scheduleflight2 = db.scheduleflight2.Find(id);
            if (scheduleflight2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.DestinationAirport = new SelectList(db.airport1, "AirportLocation", "AirportLocation", scheduleflight2.DestinationAirport);
            ViewBag.SourceAirport = new SelectList(db.airport1, "AirportLocation", "AirportLocation", scheduleflight2.SourceAirport);
            return View(scheduleflight2);
        }

        // POST: scheduleflight2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScduleId,SourceAirport,DestinationAirport,DepartureTime,ArrivalTime,TotalCost")] scheduleflight2 scheduleflight2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleflight2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DestinationAirport = new SelectList(db.airport1, "AirportLocation", "AirportLocation", scheduleflight2.DestinationAirport);
            ViewBag.SourceAirport = new SelectList(db.airport1, "AirportLocation", "AirportLocation", scheduleflight2.SourceAirport);
            return View(scheduleflight2);
        }

        // GET: scheduleflight2/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scheduleflight2 scheduleflight2 = db.scheduleflight2.Find(id);
            if (scheduleflight2 == null)
            {
                return HttpNotFound();
            }
            return View(scheduleflight2);
        }

        // POST: scheduleflight2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            scheduleflight2 scheduleflight2 = db.scheduleflight2.Find(id);
            db.scheduleflight2.Remove(scheduleflight2);
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

        public ActionResult Search(long? search)
        {
            var model = db.scheduleflight2.Where(x => x.ScduleId == search).ToList();
            return View(model);

        }
        public ActionResult welocme_Here()
        {
            return View();
        }
        [HttpPost]
        public ActionResult welcome_Here(scheduleflight2 bk)
        {
            using (FlightEntities3 db = new FlightEntities3())

            {
                db.scheduleflight2.Add(bk);
                db.SaveChanges();

                //  string name = bk.UserName;

                int amount = Convert.ToInt32(bk.TotalCost);

                ViewBag.amount = amount;
                // ViewBag.Id = id;
                // ViewBag.Name = name;
            }

            return View();
        }
    }

}
