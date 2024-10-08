﻿using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IzinSistemi.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login



        DBIzinTakipEntities db = new DBIzinTakipEntities();
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]

        public ActionResult GirisYap(Personel p)
        {
            var bilgiler = db.Personel.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
        
            // Sadece mail session getir.
            //Diğer veriler TempData yada ViewBag
            if (bilgiler != null)
            {

                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"] = bilgiler.Mail.ToString();
                TempData["Isim"] = bilgiler.Isim.ToString();
                TempData["Soyisim"]=bilgiler.Soyisim.ToString();
                TempData["KullanıcıAdı"]=bilgiler.KullanıcıAdı.ToString();
                TempData["Telefon"] = bilgiler.Telefon.ToString();
                TempData["Sifre"] = bilgiler.Sifre.ToString();
                Session["KalanIzin"] = bilgiler.KalanIzin.ToString();
                Session["KullanılanIzin"] = bilgiler.KullanılanIzin.ToString();
                TempData["ToplamIzin"] = bilgiler.ToplamIzin.ToString();
                TempData["PId"] = bilgiler.PId.ToString();
                TempData["Mail"] = bilgiler.Mail.ToString();
                return RedirectToAction("Index","Panel");
            }
            else
            {
                return View(); 
            }
        }


        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");

        }
    }
}