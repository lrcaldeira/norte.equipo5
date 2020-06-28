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
    public class CartController : BaseController
    {
        BaseDataService<Cart> db;
        public CartController()
        {
            db = new BaseDataService<Cart>();
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
        public ActionResult Create(Cart cart)
        {
            this.CheckAuditPattern(cart, true);
            var listModel = db.ValidateModel(cart);
            if (ModelIsValid(listModel))
                return View(cart);
            try
            {
                db.Create(cart);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(cart);
            }

        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cart = db.GetById(id.Value);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        [HttpPost]
        public ActionResult Edit(Cart cart, object Logger)
        {
            this.CheckAuditPattern(cart);
            var listModel = db.ValidateModel(cart);
            if (ModelIsValid(listModel))
                return View(cart);
            try
            {
                db.Update(cart);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(cart);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cart = db.GetById(id.Value);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        [HttpPost]
        public ActionResult Delete(Cart cart)
        {
            try
            {
                db.Delete(cart);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(cart);
            }
        }
    }
}