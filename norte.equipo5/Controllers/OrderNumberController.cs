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
    public class OrderNumberController : BaseController
    {
        BaseDataService<OrderNumber> db;
        public OrderNumberController()
        {
            db = new BaseDataService<OrderNumber>();
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
        public ActionResult Create(OrderNumber ordernumber)
        {
            this.CheckAuditPattern(ordernumber, true);
            var listModel = db.ValidateModel(ordernumber);
            if (ModelIsValid(listModel))
                return View(ordernumber);
            try
            {
                db.Create(ordernumber);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(ordernumber);
            }

        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ordernumber = db.GetById(id.Value);
            if (ordernumber == null)
            {
                return HttpNotFound();
            }
            return View(ordernumber);
        }

        [HttpPost]
        public ActionResult Edit(OrderNumber ordernumber, object Logger)
        {
            this.CheckAuditPattern(ordernumber);
            var listModel = db.ValidateModel(ordernumber);
            if (ModelIsValid(listModel))
                return View(ordernumber);
            try
            {
                db.Update(ordernumber);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(ordernumber);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ordernumber = db.GetById(id.Value);
            if (ordernumber == null)
            {
                return HttpNotFound();
            }
            return View(ordernumber);
        }

        [HttpPost]
        public ActionResult Delete(OrderNumber ordernumber)
        {
            try
            {
                db.Delete(ordernumber);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(ordernumber);
            }
        }
    }
}