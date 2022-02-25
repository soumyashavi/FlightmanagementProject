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
    public class AddFlightsController : Controller
    {
        private FlightEntities2 db = new FlightEntities2();

        // GET: AddFlights
        public ActionResult Index()
        {
            return View(db.AddFlights.ToList());
        }

        // GET: AddFlights/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddFlight addFlight = db.AddFlights.Find(id);
            if (addFlight == null)
            {
                return HttpNotFound();
            }
            return View(addFlight);
        }

        // GET: AddFlights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddFlights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightId,FlightName,FlightModel,FlightCarrier")] AddFlight addFlight)
        {
            if (ModelState.IsValid)
            {
                db.AddFlights.Add(addFlight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addFlight);
        }

        // GET: AddFlights/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddFlight addFlight = db.AddFlights.Find(id);
            if (addFlight == null)
            {
                return HttpNotFound();
            }
            return View(addFlight);
        }

        // POST: AddFlights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightId,FlightName,FlightModel,FlightCarrier")] AddFlight addFlight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addFlight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addFlight);
        }

        // GET: AddFlights/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddFlight addFlight = db.AddFlights.Find(id);
            if (addFlight == null)
            {
                return HttpNotFound();
            }
            return View(addFlight);
        }

        // POST: AddFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AddFlight addFlight = db.AddFlights.Find(id);
            db.AddFlights.Remove(addFlight);
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
            var model = db.AddFlights.Where(x => x.FlightId == search).ToList();
            return View(model);

        }
    }
}
