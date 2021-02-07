﻿using System;
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
        E_GIYIM_DBOEntities4 GiyimModel = new E_GIYIM_DBOEntities4();

        // GET: Email
        public ActionResult Index()
        {
            List<EMAIL> emailList = GiyimModel.EMAIL.ToList();
            return View(emailList);
        }

        // GET: Email/Details/5
        public ActionResult Details(int id)
        {
            EMAIL GoruntulenecekEmail = GiyimModel.EMAIL.Find(id);
            return View(GoruntulenecekEmail);
        }


        // GET: Email/Delete/5
        public ActionResult Delete(int id)
        {
            EMAIL GoruntulenecekEmail = GiyimModel.EMAIL.Find(id);
            return View(GoruntulenecekEmail);
        }

        // POST: Email/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                EMAIL silinecekEmail = GiyimModel.EMAIL.Find(id);

                GiyimModel.EMAIL.Remove(silinecekEmail);
                GiyimModel.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CevapVer(int id)
        {
            EMAIL GoruntulenecekEmail = GiyimModel.EMAIL.Find(id);
            return View(GoruntulenecekEmail);
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
                Credentials = new NetworkCredential(fromAddress.Address, "dura3751ChK")
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