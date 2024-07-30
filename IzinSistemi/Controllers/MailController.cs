using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using IzinSistemi.Models.Entity;

namespace IzinSistemi.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IzinTalebi model, string tut)
        {
            MailMessage mailim = new MailMessage();
            mailim.To.Add(tut);
            mailim.From = new MailAddress("ibrahimtulumcu@hotmail.com");
            mailim.Subject = "Izin Talebi Bilgilendirme. " + model.IzinTip;
            mailim.Body = "İzin talebiniz Onaylanmıştır " + model.Baslangic + "-" + model.Bitis;
            mailim.IsBodyHtml = true;

 

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("ibrahimtulumcu@hotmail.com", "");
            smtp.Port = 587;
            smtp.Host = "smtp-mail.outlook.com";
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mailim);
                TempData["Message"] = "Mesajınız iletilmiştir. En kısa zamanda size geri dönüş sağlanacaktır.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Mesaj gönderilemedi.Hata nedeni:" + ex.Message;
            }

            return View();

        }

    }
}