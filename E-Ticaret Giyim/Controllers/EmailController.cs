using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using E_Ticaret_Giyim.Models;

namespace E_Ticaret_Giyim.Controllers
{
    public class EmailController : Controller
    {
        E_GIYIM_DBOEntities4 clothingModel = new E_GIYIM_DBOEntities4();

        // GET: Email
        public ActionResult Index()
        {
            List<EMAIL> emailList = clothingModel.EMAIL.ToList();
            return View(emailList);
        }

        // GET: Email/Details/5
        public ActionResult Details(int id)
        {
            EMAIL emailToDisplay = clothingModel.EMAIL.Find(id);
            return View(emailToDisplay);
        }


        // GET: Email/Delete/5
        public ActionResult Delete(int id)
        {
            EMAIL emailToDisplay = clothingModel.EMAIL.Find(id);
            return View(emailToDisplay);
        }

        // POST: Email/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                EMAIL emailToBeDeleted = clothingModel.EMAIL.Find(id);

                clothingModel.EMAIL.Remove(emailToBeDeleted);
                clothingModel.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CevapVer(int id)
        {
            EMAIL emailToDisplay = clothingModel.EMAIL.Find(id);
            return View(emailToDisplay);
        }

        public ActionResult MesajGonder(string konu, string mesaj, string kime)
        {
            var fromAddress = new MailAddress("celilhan12363@gmail.com");
            var toAddress = new MailAddress("celilhan12363@gmail.com");
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "*******")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = konu, Body = mesaj })
                {
                    smtp.Send(message);
                }
            }
            return RedirectToAction("Iletisim");

        }
    }
}
