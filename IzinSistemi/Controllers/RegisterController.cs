using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IzinSistemi.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register


        DBIzinTakipEntities db = new DBIzinTakipEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public  ActionResult KayitOl()
        {
            return View  ();
        }

        [HttpPost]

        public ActionResult KayitOl(Personel p)
        {
            if (!ModelState.IsValid)
            {
                return View("KayitOl");
            }
            db.Personel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Panel");

        }


    }
}