﻿using Microsoft.Ajax.Utilities;
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
        BaseDataService<Artist> db;
        public ArtistController()
        {
            db = new BaseDataService<Artist>();
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
        public ActionResult Create(Artist artist)
        {
            this.CheckAuditPattern(artist, true);
            var listModel = db.ValidateModel(artist);
            if (ModelIsValid(listModel))
                return View(artist);
            try
            {
                db.Create(artist);
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
            var artist = db.GetById(id.Value);
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
            var listModel = db.ValidateModel(artist);
            if (ModelIsValid(listModel))
                return View(artist);
            try
            {
                db.Update(artist);
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
            var artist = db.GetById(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost]
        public ActionResult Delete(Artist artist)
        {
            try
            {
                db.Delete(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }
    }
}