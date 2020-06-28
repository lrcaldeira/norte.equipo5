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
    public class OrderDetailController : BaseController
    {
        BaseDataService<OrderDetail> db;
        public OrderDetailController()
        {
            db = new BaseDataService<OrderDetail>();
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
        public ActionResult Create(OrderDetail orderdetail)
        {
            this.CheckAuditPattern(orderdetail, true);
            var listModel = db.ValidateModel(orderdetail);
            if (ModelIsValid(listModel))
                return View(orderdetail);
            try
            {
                db.Create(orderdetail);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(orderdetail);
            }

        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderdetail = db.GetById(id.Value);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
        }

        [HttpPost]
        public ActionResult Edit(OrderDetail orderdetail, object Logger)
        {
            this.CheckAuditPattern(orderdetail);
            var listModel = db.ValidateModel(orderdetail);
            if (ModelIsValid(listModel))
                return View(orderdetail);
            try
            {
                db.Update(orderdetail);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(orderdetail);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderdetail = db.GetById(id.Value);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
        }

        [HttpPost]
        public ActionResult Delete(OrderDetail orderdetail)
        {
            try
            {
                db.Delete(orderdetail);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(orderdetail);
            }
        }
    }
}