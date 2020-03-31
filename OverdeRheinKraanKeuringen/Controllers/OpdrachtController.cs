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
    public class OpdrachtController : Controller
    {
        private OpdrachtContext db = new OpdrachtContext();

        // GET: Opdracht
        public ActionResult Index()
        {
            //OpdrachtViewModel opdrachtViewModel = new OpdrachtViewModel
            //{
            //    Opdrachten = db.Opdrachten.ToList()
            //};
            return View(db.Opdrachten.ToList());
        }

        // GET: Opdracht/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opdracht opdracht = db.Opdrachten.Find(id);
            if (opdracht == null)
            {
                return HttpNotFound();
            }
            return View(opdracht);
        }

        // GET: Opdracht/Create
        public ActionResult Create()
        {
            //OpdrachtViewModel opdrachtViewModel = new OpdrachtViewModel(new Opdracht());
            return View(/*opdrachtViewModel*/);
        }

        // POST: Opdracht/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OpdrachtNummer,WerkInstructie,DatumUitvoering,KabelLeverancier,Waarnemingen,Image,Bedrijfsuren,AflegRedenen")] Opdracht opdracht)
        {
            if (ModelState.IsValid)
            {
                db.Opdrachten.Add(opdracht);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opdracht);
        }

        // GET: Opdracht/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opdracht opdracht = db.Opdrachten.Find(id);
            //OpdrachtViewModel opdrachtViewModel = new OpdrachtViewModel(opdracht);
            if (opdracht == null)
            {
                return HttpNotFound();
            }
            return View(opdracht);
        }

        // POST: Opdracht/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpdrachtNummer,WerkInstructie,DatumUitvoering,KabelLeverancier,Waarnemingen,Image,Bedrijfsuren,AflegRedenen")] Opdracht opdracht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opdracht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opdracht);
        }

        // GET: Opdracht/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opdracht opdracht = db.Opdrachten.Find(id);
            if (opdracht == null)
            {
                return HttpNotFound();
            }
            return View(opdracht);
        }

        // POST: Opdracht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opdracht opdracht = db.Opdrachten.Find(id);
            db.Opdrachten.Remove(opdracht);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddChecklist(string returnUrl, int? OpdrachtNummer)
        {
            IEnumerable<Kabelchecklist> getChecklists = db.Kabelchecklists.ToList().Where(k => k.Opdrachtnummer == OpdrachtNummer);
            ViewBag.returnurl = returnUrl;
            ViewBag.OpdrachtNummer = OpdrachtNummer;

            return View(getChecklists);
        }

        public ActionResult AddChecklists(int? id, string returnUrl, int? OpdrachtNummer)
        {
            if (id == null || OpdrachtNummer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kabelchecklist tempChecklist = db.Kabelchecklists.ToList().Where(s => s.KabelID == id).FirstOrDefault();

            if (tempChecklist == null)
            {
                return HttpNotFound();
            }

            Opdracht opdracht = db.Opdrachten.Where(s => s.OpdrachtNummer == OpdrachtNummer).FirstOrDefault();

            opdracht.Kabelchecklists.Add(tempChecklist);

            db.Entry(opdracht).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Redirect(returnUrl);
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
