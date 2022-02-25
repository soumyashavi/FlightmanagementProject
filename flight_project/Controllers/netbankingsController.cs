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
    public class netbankingsController : Controller
    {
        private FlightEntities6 db = new FlightEntities6();

        // GET: netbankings
        public ActionResult Index()
        {
            return View(db.netbankings.ToList());
        }

        // GET: netbankings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            netbanking netbanking = db.netbankings.Find(id);
            if (netbanking == null)
            {
                return HttpNotFound();
            }
            return View(netbanking);
        }

        // GET: netbankings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: netbankings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardNumber,Name,CVC")] netbanking netbanking)
        {
            if (ModelState.IsValid)
            {
                db.netbankings.Add(netbanking);
                db.SaveChanges();
               // return RedirectToAction("Index");
            }
            
            ViewBag.Message = "Payment Successful";

            return View(netbanking);

        }

        // GET: netbankings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            netbanking netbanking = db.netbankings.Find(id);
            if (netbanking == null)
            {
                return HttpNotFound();
            }
            return View(netbanking);
        }

        // POST: netbankings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardNumber,Name,CVC")] netbanking netbanking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(netbanking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(netbanking);
        }

        // GET: netbankings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            netbanking netbanking = db.netbankings.Find(id);
            if (netbanking == null)
            {
                return HttpNotFound();
            }
            return View(netbanking);
        }

        // POST: netbankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            netbanking netbanking = db.netbankings.Find(id);
            db.netbankings.Remove(netbanking);
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

        public ActionResult Payment()
        {
            return View();
        }
    }
}
