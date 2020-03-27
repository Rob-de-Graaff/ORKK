using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OverdeRheinKraanKeuringen.DAL;
using OverdeRheinKraanKeuringen.Models;

namespace OverdeRheinKraanKeuringen.Controllers
{
    public class KabelchecklistController : Controller
    {
        private OpdrachtContext db = new OpdrachtContext();

        // GET: Kabelchecklist
        public ActionResult Index()
        {
            var kabelchecklists = db.Kabelchecklists.Include(k => k.Opdracht);
            return View(kabelchecklists.ToList());
        }

        // GET: Kabelchecklist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kabelchecklist kabelchecklist = db.Kabelchecklists.Find(id);
            if (kabelchecklist == null)
            {
                return HttpNotFound();
            }
            return View(kabelchecklist);
        }

        // GET: Kabelchecklist/Create
        public ActionResult Create()
        {
            ViewBag.Opdrachtnummer = new SelectList(db.Opdrachten, "OpdrachtNummer", "OpdrachtNummer");
            return View();
        }

        // POST: Kabelchecklist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KabelID,Breuk6D,Breuk30D,BeschadigingBuitenzijde,BeschadigingRoestCorrosie,VerminderdeKabeldiameter,PositieMeetpunten,BeschadigingTotaal,Opdrachtnummer")] Kabelchecklist kabelchecklist)
        {
            if (ModelState.IsValid)
            {
                db.Kabelchecklists.Add(kabelchecklist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Opdrachtnummer = new SelectList(db.Opdrachten, "OpdrachtNummer", "OpdrachtNummer", kabelchecklist.Opdrachtnummer);
            return View(kabelchecklist);
        }

        // GET: Kabelchecklist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kabelchecklist kabelchecklist = db.Kabelchecklists.Find(id);
            if (kabelchecklist == null)
            {
                return HttpNotFound();
            }
            ViewBag.Opdrachtnummer = new SelectList(db.Opdrachten, "OpdrachtNummer", "WerkInstructie", kabelchecklist.Opdrachtnummer);
            return View(kabelchecklist);
        }

        // POST: Kabelchecklist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KabelID,Breuk6D,Breuk30D,BeschadigingBuitenzijde,BeschadigingRoestCorrosie,VerminderdeKabeldiameter,PositieMeetpunten,BeschadigingTotaal,Opdrachtnummer")] Kabelchecklist kabelchecklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kabelchecklist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Opdrachtnummer = new SelectList(db.Opdrachten, "OpdrachtNummer", "WerkInstructie", kabelchecklist.Opdrachtnummer);
            return View(kabelchecklist);
        }

        // GET: Kabelchecklist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kabelchecklist kabelchecklist = db.Kabelchecklists.Find(id);
            if (kabelchecklist == null)
            {
                return HttpNotFound();
            }
            return View(kabelchecklist);
        }

        // POST: Kabelchecklist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kabelchecklist kabelchecklist = db.Kabelchecklists.Find(id);
            db.Kabelchecklists.Remove(kabelchecklist);
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
