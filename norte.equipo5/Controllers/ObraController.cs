using norte.equipo5.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace norte.equipo5.Controllers
{
    public class ObraController : Controller
    {
        private IObraData db;

        public ObraController()
        {
            db = new InMemoryObraData();
        }

        public ActionResult Index()
        {
            var list = db.GetAll();
            return View(list);
        }
    }
}