using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IzinSistemi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        DBIzinTakipEntities db = new DBIzinTakipEntities();
        public ActionResult Index()
        {
            var item = db.İzinTipi.ToList();
            return View(item);
        }

        [HttpGet]

        public ActionResult TipEkle()
        {
            var item = db.İzinTipi.ToList();
            return View(item);
        }


        [HttpPost]
        public ActionResult TipEkle(İzinTipi p)
        {
            if (!ModelState.IsValid)
            {
                return View("TipEkle");
            }
            db.İzinTipi.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var item = db.İzinTipi.Find(id);
            db.İzinTipi.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IzinTipiGetir(int id)
        {
            var item = db.İzinTipi.Find(id);
            return View("IzinTipiGetir",item);
        }
        public ActionResult Guncelle(İzinTipi p)
        {
            var item = db.İzinTipi.Find(p.Id);
            item.Tip = p.Tip;
            item.Saat = p.Saat;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}