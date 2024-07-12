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
        public ActionResult KayıtOl(Personel p)
        {
            if (!ModelState.IsValid)
            {
                return View("KayıtOl");
            }
            db.Personel.Add(p);
            db.SaveChanges();
            return View();

        }


    }
}