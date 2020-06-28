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
    public class OrderController : BaseController
    {
        BaseDataService<Order> db;
        public OrderController()
        {
            db = new BaseDataService<Order>();
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
        public ActionResult Create(Order order)
        {
            this.CheckAuditPattern(order, true);
            var listModel = db.ValidateModel(order);
            if (ModelIsValid(listModel))
                return View(order);
            try
            {
                db.Create(order);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(order);
            }

        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.GetById(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order, object Logger)
        {
            this.CheckAuditPattern(order);
            var listModel = db.ValidateModel(order);
            if (ModelIsValid(listModel))
                return View(order);
            try
            {
                db.Update(order);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(order);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.GetById(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        public ActionResult Delete(Order order)
        {
            try
            {
                db.Delete(order);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(order);
            }
        }
    }
}