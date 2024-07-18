using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IzinSistemi.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        

        DBIzinTakipEntities db = new DBIzinTakipEntities();


        [Authorize]

     
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.Personel.FirstOrDefault(z => z.Mail == uyemail);

            Session["PId"] = degerler.PId;
            return View(degerler);
        }

        //[HttpPost]
        //public ActionResult Index(Personel p)
        //{
        //    var kullanici = (string)Session["Mail"];
        //    var uye = db.Personel.FirstOrDefault(x => x.Mail == kullanici);
        //    uye.Sifre = p.Sifre;
        //    db.SaveChanges();
        //    return View();

        //}


        [HttpPost]
        public ActionResult Index2(Personel p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.Personel.FirstOrDefault(x => x.Mail == kullanici);
            uye.Sifre = p.Sifre;
            
            uye.Isim = p.Isim;
            uye.Soyisim = p.Soyisim;
            uye.KullanıcıAdı = p.KullanıcıAdı;
            uye.Telefon = p.Telefon;
            
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}