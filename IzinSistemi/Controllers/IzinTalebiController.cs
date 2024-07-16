using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IzinSistemi.Controllers
{
    public class IzinTalebiController : Controller
    {
        // GET: IzinTalebi

        DBIzinTakipEntities db = new DBIzinTakipEntities();
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult Talep()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Talep(IzinTalebi p)
        {
            
            db.IzinTalebi.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }



}