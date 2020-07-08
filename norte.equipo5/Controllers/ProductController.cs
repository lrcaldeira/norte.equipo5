using Microsoft.Ajax.Utilities;
using Microsoft.Build.Utilities;
using norte.equipo5.Data.Model;
using norte.equipo5.Data.Services;
using norte.equipo5.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logger = norte.equipo5.Service.Logger;

namespace norte.equipo5.Controllers
{
    public class ProductController : BaseController
    {

        private readonly BaseDataService<Product> MyContext = new BaseDataService<Product>();
        private readonly GaleriaDBContext db = new GaleriaDBContext();
       
        public ActionResult Index()
        {
            var products = MyContext.Get(null, null, "Artist");

            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product Product, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("/content/Products"), filename);
                    file.SaveAs(path);

                    Product.Image = filename;
                    this.CheckAuditPattern(Product, true);
                    db.Product.Add(Product);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }

            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
            }
            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName", Product.ArtistId);
            ViewBag.MessageDanger = "¡Error al cargar el Producto con su imagén.";
            return View(Product);
        }


            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName", product.ArtistId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product Product, HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("/content/products"), filename);
                    file.SaveAs(path);
                    Product.Image = filename;
                }
                this.CheckAuditPattern(Product, false);
                db.Entry(Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
            }

            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName", Product.ArtistId);
            ViewBag.MessageDanger = "¡Error al modificar el Producto con su imagén.";
            return View(Product);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Product = MyContext.GetById(id.Value);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            db.Product.Remove(product);
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

