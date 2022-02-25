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
    public class upi1Controller : Controller
    {
        private FlightEntities11 db = new FlightEntities11();

        // GET: upi1
        public ActionResult Index()
        {
            return View(db.upi1.ToList());
        }

        // GET: upi1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            upi1 upi1 = db.upi1.Find(id);
            if (upi1 == null)
            {
                return HttpNotFound();
            }
            return View(upi1);
        }

        // GET: upi1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: upi1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,UPI_Id,UPI_PIN")] upi1 upi1)
        {
            if (ModelState.IsValid)
            {
                db.upi1.Add(upi1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(upi1);
        }

        // GET: upi1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            upi1 upi1 = db.upi1.Find(id);
            if (upi1 == null)
            {
                return HttpNotFound();
            }
            return View(upi1);
        }

        // POST: upi1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,UPI_Id,UPI_PIN")] upi1 upi1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(upi1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(upi1);
        }

        // GET: upi1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            upi1 upi1 = db.upi1.Find(id);
            if (upi1 == null)
            {
                return HttpNotFound();
            }
            return View(upi1);
        }

        // POST: upi1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            upi1 upi1 = db.upi1.Find(id);
            db.upi1.Remove(upi1);
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
