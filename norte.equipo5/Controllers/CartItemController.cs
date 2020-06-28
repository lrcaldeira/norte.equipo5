using Microsoft.Build.Utilities;
using norte.equipo5.Data.Model;
using norte.equipo5.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logger = norte.equipo5.Service.Logger;


namespace norte.equipo5.Controllers
{
    public class CartItemController : BaseController
    {
        BaseDataService<CartItem> db;
        public CartItemController()
        {
            db = new BaseDataService<CartItem>();
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
        public ActionResult Create(CartItem cartitem)
        {
            this.CheckAuditPattern(cartitem, true);
            var listModel = db.ValidateModel(cartitem);
            if (ModelIsValid(listModel))
                return View(cartitem);
            try
            {
                db.Create(cartitem);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(cartitem);
            }

        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cartitem = db.GetById(id.Value);
            if (cartitem == null)
            {
                return HttpNotFound();
            }
            return View(cartitem);
        }

        [HttpPost]
        public ActionResult Edit(CartItem cartitem, object Logger)
        {
            this.CheckAuditPattern(cartitem);
            var listModel = db.ValidateModel(cartitem);
            if (ModelIsValid(listModel))
                return View(cartitem);
            try
            {
                db.Update(cartitem);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(cartitem);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cartitem = db.GetById(id.Value);
            if (cartitem == null)
            {
                return HttpNotFound();
            }
            return View(cartitem);
        }

        [HttpPost]
        public ActionResult Delete(CartItem cartitem)
        {
            try
            {
                db.Delete(cartitem);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(cartitem);
            }
        }
    }
}