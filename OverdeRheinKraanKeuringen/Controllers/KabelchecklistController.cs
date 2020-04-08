using OverdeRheinKraanKeuringen.DAL;
using OverdeRheinKraanKeuringen.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
        public ActionResult Create(int opdrachtNummer)
        {
            //ViewBag.Opdrachtnummer = new SelectList(db.Opdrachten, "OpdrachtNummer", "OpdrachtNummer");
            return View(new Kabelchecklist(opdrachtNummer));
        }

        // POST: Kabelchecklist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Breuk6D,Breuk30D,BeschadigingBuitenzijde,BeschadigingRoestCorrosie,VerminderdeKabeldiameter,PositieMeetpunten,BeschadigingTotaal,TypeBeschadigingEnVervormingen,Opdrachtnummer")] Kabelchecklist kabelchecklist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Kabelchecklists.Add(kabelchecklist);
                    db.SaveChanges();
                    return RedirectToAction("Details", "Opdracht", new { id = kabelchecklist.Opdrachtnummer });
                }
            }
            catch (DataException Dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View("Error", new HandleErrorInfo(Dex, "Kabelchecklist", "Create"));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View("Error", new HandleErrorInfo(ex, "Kabelchecklist", "Create"));
            }

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

            //ViewBag.Opdrachtnummer = db.Opdrachten.ToList();
            return View(kabelchecklist);
        }

        // POST: Kabelchecklist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kabelchecklist kabelchecklistToUpdate = db.Kabelchecklists.Find(id);
            if (TryUpdateModel(kabelchecklistToUpdate, "", new string[] { "Breuk6D", "Breuk30D", "BeschadigingBuitenzijde", "BeschadigingRoestCorrosie", "VerminderdeKabeldiameter", "PositieMeetpunten", "BeschadigingTotaal", "TypeBeschadigingEnVervormingen", "Opdrachtnummer" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException Dex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    return View("Error", new HandleErrorInfo(Dex, "Kabelchecklist", "Edit"));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    return View("Error", new HandleErrorInfo(ex, "Kabelchecklist", "Edit"));
                }
            }
            
            return View(kabelchecklistToUpdate);
        }

        // GET: Kabelchecklist/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Kabelchecklist kabelchecklist = db.Kabelchecklists.Find(id);
            if (kabelchecklist == null)
            {
                return HttpNotFound();
            }
            return View(kabelchecklist);
        }

        // POST: Kabelchecklist/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Kabelchecklist kabelchecklist = db.Kabelchecklists.Find(id);
                db.Kabelchecklists.Remove(kabelchecklist);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }

            return RedirectToAction("Details", "Opdracht", new { id });
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