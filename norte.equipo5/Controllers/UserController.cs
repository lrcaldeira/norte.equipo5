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
    public class UserController : BaseController
    {
        BaseDataService<User> db;
        public UserController()
        {
            db = new BaseDataService<User>();
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
        public ActionResult Create(User user)
        {
            this.CheckAuditPattern(user, true);
            var listModel = db.ValidateModel(user);
            if (ModelIsValid(listModel))
                return View(user);
            try
            {
                db.Create(user);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(user);
            }

        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user, object Logger)
        {
            this.CheckAuditPattern(user);
            var listModel = db.ValidateModel(user);
            if (ModelIsValid(listModel))
                return View(user);
            try
            {
                db.Update(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(user);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {
            try
            {
                db.Delete(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(user);
            }
        }
    }
}