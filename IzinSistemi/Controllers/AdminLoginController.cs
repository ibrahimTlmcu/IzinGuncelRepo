using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IzinSistemi.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DBIzinTakipEntities db = new DBIzinTakipEntities();
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
      
        public ActionResult Login(Admin a)
        {
            var bilgiler = db.Admin.FirstOrDefault(x => x.KullanıcıAdı == a.KullanıcıAdı && x.Sifre == a.Sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullanıcıAdı, false);
                Session["KullanıcıAdı"] = bilgiler.KullanıcıAdı.ToString();
                return RedirectToAction("TalepGetir", "IzinTalebi");
            }
            return View();
        }


        [HttpGet]
        public ActionResult AdminGuncelle()
        {
            return View();  
        }


        [HttpPost]
        public ActionResult AdminGuncelle(Admin p)
        {

            var bilgiler = db.Admin.FirstOrDefault(x => x.KullanıcıAdı == p.KullanıcıAdı && x.Sifre == p.Sifre);
           
            
            var kullanici = (string)Session["Mail"];
            var uye = db.Personel.FirstOrDefault(x => x.Mail == kullanici);
            uye.Sifre = p.Sifre;
            uye.KullanıcıAdı = p.KullanıcıAdı;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}