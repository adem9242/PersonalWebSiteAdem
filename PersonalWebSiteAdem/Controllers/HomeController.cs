using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PersonalWebSiteAdem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
       
        public ActionResult iletisim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult iletisim(string name, string email, string subject, string message, string dogru,string yanlis)
        {


            if (name != "" && email != "" && subject != "" && message != "")
            {

                MailMessage loginInfo = new MailMessage();

                loginInfo.To.Add("adem_1325@hotmail.com");
                loginInfo.From = new MailAddress("ylmz_9242@hotmail.com");
                loginInfo.Subject = subject.ToString();

                loginInfo.Body = "Kişinin Adı:" + name.ToString()+"\n"+"Kişinin mail:"+email+"\n" + message;
                loginInfo.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.live.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.Credentials = new System.Net.NetworkCredential("ylmz_9242@hotmail.com", "19921905SA");

                smtp.Send(loginInfo);

                ViewBag.dogru = "Mesajınız başarıyla gönderildi.";
            }
            else
            {
                ViewBag.yanlis = "Lütfen boş alanları doldurunuz.";
            }
             return View();
        }

    }
}