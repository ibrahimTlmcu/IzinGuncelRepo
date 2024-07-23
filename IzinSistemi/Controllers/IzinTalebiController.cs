using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;

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
            List<SelectListItem> deger1 = (from x in db.İzinTipi.ToList() select new SelectListItem { Text = x.Id + " " + x.Tip, Value = x.Id.ToString() }).ToList();
            //List<SelectListItem> deger2 = (from x in db.IzinTalebi.ToList() select new SelectListItem { Text = x.Id.ToString() == U}).ToList();
            ViewBag.dgr1 = deger1;   
            //ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        
        public ActionResult Talep(IzinTalebi model)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.Personel.FirstOrDefault(x => x.Mail == kullanici);

            if (uye != null)
            {
                // Gelen izin tipini başka bir tabloya aktaralım
                var yeniIzin = new IzinTalebi
                {
                    IzinTip = model.IzinTip,
                    Detay = model.Detay,
                    IzinTalepPersoneId = uye.PId,  // İlgili personelin ID'si
                    Baslangic = model.Baslangic,
                    Bitis = model.Bitis,
                    Gun = model.Gun,
                   
                };



                db.IzinTalebi.Add(yeniIzin);
                db.SaveChanges();
            }

            return RedirectToAction("Index","Panel");
        }

        [Authorize(Roles ="B")]
        public ActionResult TalepGetir()
        {

            var degerler = db.IzinTalebi.ToList();
            return View(degerler);
        }

       
        public ActionResult TalepOnay1(IzinTalebi P )
        {

            var personeltut = db.Personel;

            MailController newMail = new MailController();
            var gun = P.Gun;
            var id = P.Id;
            var deger = db.IzinTalebi.FirstOrDefault(i => i.Id == P.Id);
            

            var personel1 = deger.Gun;
            var kullanici = (string)Session["Mail"];
            var uye = db.Personel.FirstOrDefault(x => x.Mail == kullanici);


            var personel = deger.IzinTalepPersoneId;
            var tut = deger.Personel.Mail;
            var personell = db.Personel.Find(personel);
            
            var deger2 = db.Personel.Find(personel);

        
            
            var izinmiktarı = P.Gun;
            
            if(deger != null)
            {
                deger.Onay = true;
                deger2.KalanIzin = deger2.KalanIzin - personel1;
                deger2.KullanılanIzin = deger2.KullanılanIzin + personel1;
                newMail.Index(P, tut);
                db.SaveChanges();
            }
         
            var deger1 = db.IzinTalebi.ToList();
            return RedirectToAction("TalepGetir","IzinTalebi");
        }
        public ActionResult TalepSil(IzinTalebi P)
        {
            var id = P.Id;
            var deger = db.IzinTalebi.FirstOrDefault(i => i.Id == id);

            db.IzinTalebi.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index","Panel");
        }


        //[HttpPost]
        //public ActionResult Mail(IzinTalebi model)
        //{
        //    MailMessage mailim = new MailMessage();
        //    mailim.To.Add("ibrahimtulumcu@hotmail.com");
        //    mailim.From = new MailAddress("ibrahimtulumcu@hotmail.com");
        //    mailim.Subject = "Bize Ulaşın Sayfasından Mesajınız Var. " + model.Baslangic;
        //    mailim.Body = "Sayın yetkili, " + model.Bitis;
        //    mailim.IsBodyHtml = true;


        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Credentials = new NetworkCredential("ibrahimtulumcu@hotmail.com", "chtd iids rorl wzpw");
        //    smtp.Port = 587;
        //    smtp.Host = "smtp.hotmail.com";
        //    smtp.EnableSsl = true;

        //    try
        //    {
        //        smtp.Send(mailim);
        //        TempData["Message"] = "Mesajınız iletilmiştir. En kısa zamanda size geri dönüş sağlanacaktır.";
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Message"] = "Mesaj gönderilemedi.Hata nedeni:" + ex.Message;
        //    }

        //    return View();

        //}



    }



}