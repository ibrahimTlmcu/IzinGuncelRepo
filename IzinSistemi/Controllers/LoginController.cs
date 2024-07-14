using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IzinSistemi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBIzinTakipEntities db = new DBIzinTakipEntities();

        public ActionResult Index()
        {
            return View();
        }   

        [HttpPost]

        public ActionResult GirisYap(Personel p)
        {
            var bilgiler = db.Personel.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }

        }

       
    }
}