using OverdeRheinKraanKeuringen.DAL;
using OverdeRheinKraanKeuringen.ExtensionMethods;
using OverdeRheinKraanKeuringen.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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

        public async Task<ActionResult> RenderImage(int id)
        {
            Opdracht opdracht = await db.Opdrachten.FindAsync(id);

            byte[] imageBytes = opdracht.Image;

            return File(imageBytes, $"{ImageExtension.GetMimeTypeFromImageByteArray(imageBytes)}");
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
            return View(new Opdracht{DatumUitvoering = DateTime.Now});
        }

        // POST: Opdracht/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WerkInstructie,DatumUitvoering,KabelLeverancier,Waarnemingen,Image,Bedrijfsuren,AflegRedenen")] Opdracht opdracht, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        opdracht.Image = ImageExtension.ConvertImage(path);

                        db.Opdrachten.Add(opdracht);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
                catch (DataException Dex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    return View("Error", new HandleErrorInfo(Dex, "Opdracht", "Create"));
                }
                catch (FileNotFoundException FNFex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    return View("Error", new HandleErrorInfo(FNFex, "Opdracht", "Create"));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    return View("Error", new HandleErrorInfo(ex, "Opdracht", "Create"));
                }
            }
            else
            {
                ViewBag.FileNotSpecifiedErrorMessage = "You have not specified a file.";
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

        #region example
        // POST: Opdracht/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase file)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opdracht opdrachtToUpdate = db.Opdrachten.Find(id);
            if (file == null || file.ContentLength <= 0)
            {
                ViewBag.FileNotSpecifiedErrorMessage = "A file must be specified.";
            }
            else
            {
                opdrachtToUpdate = db.Opdrachten.Find(id);
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                opdrachtToUpdate.Image = ImageExtension.ConvertImage(path);

                if (TryUpdateModel(opdrachtToUpdate, "", new string[] { "WerkInstructie", "DatumUitvoering", "KabelLeverancier", "Waarnemingen", "Image", "Bedrijfsuren", "AflegRedenen" }))
                {
                    try
                    {
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    catch (DataException Dex)
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                        return View("Error", new HandleErrorInfo(Dex, "Opdracht", "Edit"));
                    }
                    catch (FileNotFoundException FNFex)
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                        return View("Error", new HandleErrorInfo(FNFex, "Opdracht", "Edit"));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                        return View("Error", new HandleErrorInfo(ex, "Opdracht", "Edit"));
                    }
                }
            }

            return View(opdrachtToUpdate);
        }
        #endregion
        #region default
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "OpdrachtNummer,WerkInstructie,DatumUitvoering,KabelLeverancier,Waarnemingen,Image,Bedrijfsuren,AflegRedenen")] Opdracht opdracht, HttpPostedFileBase file)
        //{
        //    if (file != null && file.ContentLength > 0)
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
        //                file.SaveAs(path);
        //                opdracht.Image = ImageExtension.ConvertImage(path);

        //                db.Entry(opdracht).State = EntityState.Modified;
        //                db.SaveChanges();

        //                return RedirectToAction("Index");
        //            }
        //        }
        //        catch (DataException Dex)
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //            return View("Error", new HandleErrorInfo(Dex, "Opdracht", "Edit"));
        //        }
        //        catch (FileNotFoundException FNFex)
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //            return View("Error", new HandleErrorInfo(FNFex, "Opdracht", "Edit"));
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //            return View("Error", new HandleErrorInfo(ex, "Opdracht", "Edit"));
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.FileNotSpecifiedErrorMessage = "You have not specified a file.";
        //    }

        //    return View(opdracht);
        //}
        #endregion

        // GET: Opdracht/Delete/5
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
            Opdracht opdracht = db.Opdrachten.Find(id);
            if (opdracht == null)
            {
                return HttpNotFound();
            }
            return View(opdracht);
        }

        // POST: Opdracht/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Opdracht opdracht = db.Opdrachten.Find(id);
                db.Opdrachten.Remove(opdracht);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
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