using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IzinSistemi.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar

        DBIzinTakipEntities db = new DBIzinTakipEntities();
        public ActionResult Index()
        {
            var item = db.Admin.ToList();
            return View(item);
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
              return View();    
        }
        [HttpPost]
        public ActionResult YeniAdmin(Admin admin)
        {
            db.Admin.Add(admin);
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            var admin = db.Admin.Find(id);
            db.Admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGuncelle(int Id)
        {
            var item = db.Admin.Find(Id);
            return View("AdminGuncelle", item);
        }


        [HttpPost]
        public ActionResult AdminGuncelle(Admin a)
        {
            var admin = db.Admin.Find(a.Id);
            admin.KullanıcıAdı = a.KullanıcıAdı;
            admin.Sifre = a.Sifre;
            admin.Yetki = a.Yetki;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}