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
    public class admin1Controller : Controller
    {
        private FlightEntities1 db = new FlightEntities1();

        // GET: admin1
        public ActionResult Index()
        {
            return View(db.admin1.ToList());
        }

        // GET: admin1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin1 admin1 = db.admin1.Find(id);
            if (admin1 == null)
            {
                return HttpNotFound();
            }
            return View(admin1);
        }

        // GET: admin1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Password")] admin1 admin1)
        {
            if (ModelState.IsValid)
            {
                db.admin1.Add(admin1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin1);
        }

        // GET: admin1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin1 admin1 = db.admin1.Find(id);
            if (admin1 == null)
            {
                return HttpNotFound();
            }
            return View(admin1);
        }

        // POST: admin1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Password")] admin1 admin1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin1);
        }

        // GET: admin1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin1 admin1 = db.admin1.Find(id);
            if (admin1 == null)
            {
                return HttpNotFound();
            }
            return View(admin1);
        }

        // POST: admin1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admin1 admin1 = db.admin1.Find(id);
            db.admin1.Remove(admin1);
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
