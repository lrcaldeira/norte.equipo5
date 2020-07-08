using Microsoft.Ajax.Utilities;
using Microsoft.Build.Utilities;
using norte.equipo5.Data.Model;
using norte.equipo5.Data.Services;
using norte.equipo5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logger = norte.equipo5.Service.Logger;

namespace norte.equipo5.Controllers
{
    [Authorize]
    public class ArtistController : BaseController
    {
        private readonly BaseDataService<Artist> MyContext = new BaseDataService<Artist>();
        private readonly GaleriaDBContext db = new GaleriaDBContext();
        public ActionResult Index()
        {
            var list = MyContext.Get();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            this.CheckAuditPattern(artist, true);
            var listModel = MyContext.ValidateModel(artist);
            if (ModelIsValid(listModel))
                return View(artist);
            try
            {
                MyContext.Create(artist);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }

        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = MyContext.GetById(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist artist, object Logger)
        {
            this.CheckAuditPattern(artist);
            var listModel = MyContext.ValidateModel(artist);
            if (ModelIsValid(listModel))
                return View(artist);
            try
            {
                MyContext.Update(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
               
                //Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = MyContext.GetById(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var artist = db.Artist.Find(id);

            if (artist == null)
            {

                return HttpNotFound();
            }
            db.Artist.Remove(artist);
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