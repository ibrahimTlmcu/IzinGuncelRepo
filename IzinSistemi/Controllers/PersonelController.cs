using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IzinSistemi.Controllers
{
    [Authorize(Roles ="B")]
    public class PersonelController : Controller
    {
        // GET: Personel
        DBIzinTakipEntities db = new DBIzinTakipEntities();

        public ActionResult Index(string p )
        {
            var item = db.Personel.ToList();
            return View(item);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.Personel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Sil(int id)
        {
            var item = db.Personel.Find(id);
            db.Personel.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var item = db.Personel.Find(id);
            return View("PersonelGetir",item);
        }

        public ActionResult Guncelle(Personel p)
        {
            var item = db.Personel.Find(p.PId);
            item.Isim = p.Isim;
            item.Soyisim = p.Soyisim;
            item.KullanıcıAdı = p.KullanıcıAdı;
            item.Telefon = p.KullanıcıAdı;
            item.Mail = p.Mail;
            item.KullanılanIzin = p.KullanılanIzin;
            item.KalanIzin = p.KalanIzin;


            return RedirectToAction("Index");   
        }

    }
}