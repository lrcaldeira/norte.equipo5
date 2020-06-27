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
    public class ProductController : BaseController
    {
      
        BaseDataService<Product> db;
        public ProductController()
        {
            db = new BaseDataService<Product>();
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
        public ActionResult Create(Product Product)
        {
            this.CheckAuditPattern(Product, true);
            var listModel = db.ValidateModel(Product);
            if (ModelIsValid(listModel))
                return View(Product);
            try
            {
                db.Create(Product);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(Product);
            }

        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product Product, object Logger)
        {
            this.CheckAuditPattern(Product);
            var listModel = db.ValidateModel(Product);
            if (ModelIsValid(listModel))
                return View(Product);
            try
            {
                db.Update(Product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(Product);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Product = db.GetById(id.Value);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        [HttpPost]
        public ActionResult Delete(Product Product)
        {
            try
            {
                db.Delete(Product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(Product);
            }
        }
    }
}
