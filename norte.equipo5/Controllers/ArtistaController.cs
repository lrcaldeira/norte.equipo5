using norte.equipo5.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace norte.equipo5.Controllers
{
    public class ArtistaController : Controller
    {
        private IArtistaData db;

        public ArtistaController()
        {
            db = new InMemoryArtistaData();
        }

        public ActionResult Index()
        {
            var list = db.GetAll();
            return View(list);
        }
    }
}