using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IzinSistemi.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DBIzinTakipEntities db = new DBIzinTakipEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin a)
        {
            var bilgiler = db.Admin.FirstOrDefault(x => x.KullanıcıAdı == a.KullanıcıAdı && x.Sifre == a.Sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullanıcıAdı, false);
                Session["KullanıcıAdı"] = bilgiler.KullanıcıAdı.ToString();
                return RedirectToAction("Index", "Home");   
            }
            return View();
        }



    }
}