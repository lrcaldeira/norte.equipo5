using norte.equipo5.Data.Model;
using norte.equipo5.Data.Services;
using norte.equipo5.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace norte.equipo5.Controllers
{
    public class RatingController : BaseController
    {
        BaseDataService<Rating> db;
        public RatingController()
        {
            db = new BaseDataService<Rating>();
        }
        public ActionResult Index()
        {
            var list = db.Get();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rating rating)
        {
            this.CheckAuditPattern(rating, true);
            var listModel = db.ValidateModel(rating);
            if (ModelIsValid(listModel))
                return View(rating);
            try
            {
                db.Create(rating);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(rating);
            }

        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rating = db.GetById(id.Value);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        [HttpPost]
        public ActionResult Edit(Rating rating, object Logger)
        {
            this.CheckAuditPattern(rating);
            var listModel = db.ValidateModel(rating);
            if (ModelIsValid(listModel))
                return View(rating);
            try
            {
                db.Update(rating);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(rating);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rating = db.GetById(id.Value);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        [HttpPost]
        public ActionResult Delete(Rating rating)
        {
            try
            {
                db.Delete(rating);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(rating);
            }
        }
    }
}