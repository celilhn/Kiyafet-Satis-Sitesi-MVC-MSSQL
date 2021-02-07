using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret_Giyim.Models;

namespace E_Ticaret_Giyim.Controllers
{
    public class KullanıcıController : Controller
    {
        E_GIYIM_DBOEntities4 GiyimModel = new E_GIYIM_DBOEntities4();
        // GET: Kullanıcı
        public ActionResult Index()
        {
            List<KULLANICILAR> kullaniciList = GiyimModel.KULLANICILAR.ToList();
            return View(kullaniciList);
        }

        // GET: Kullanıcı/Details/5
        public ActionResult Details(int id)
        {
            KULLANICILAR GoruntulenecekKullanici = GiyimModel.KULLANICILAR.Find(id);
            return View(GoruntulenecekKullanici);
        }

        // GET: Kullanıcı/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanıcı/Create
        [HttpPost]
        public ActionResult Create(KULLANICILAR model)
        {
            try
            {
                KULLANICILAR yeniKullanici = new KULLANICILAR();
                yeniKullanici.Kullanici_Ad = model.Kullanici_Ad;
                yeniKullanici.Kullanici_Adres = model.Kullanici_Adres;
                yeniKullanici.Kullanici_Email = model.Kullanici_Email;
                yeniKullanici.Kullanici_Sifre = model.Kullanici_Sifre;
                yeniKullanici.Rol_ID = model.Rol_ID;
                yeniKullanici.Bakiye = model.Bakiye;
                yeniKullanici.Cinsiyet_ID = model.Cinsiyet_ID;

                GiyimModel.KULLANICILAR.Add(yeniKullanici);
                GiyimModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanıcı/Edit/5
        public ActionResult Edit(int id)
        {
            KULLANICILAR GoruntulenecekKullanici = GiyimModel.KULLANICILAR.Find(id);
            return View(GoruntulenecekKullanici);
        }

        // POST: Kullanıcı/Edit/5
        [HttpPost]
        public ActionResult Edit(KULLANICILAR model)
        {
            try
            {
                KULLANICILAR duzenlenecekKullanici = GiyimModel.KULLANICILAR.Find(model.Kullanici_ID);
                duzenlenecekKullanici.Kullanici_Ad = model.Kullanici_Ad;
                duzenlenecekKullanici.Kullanici_Adres = model.Kullanici_Adres;
                duzenlenecekKullanici.Kullanici_Email = model.Kullanici_Email;
                duzenlenecekKullanici.Kullanici_Sifre = model.Kullanici_Sifre;
                duzenlenecekKullanici.Bakiye = model.Bakiye;
                duzenlenecekKullanici.Rol_ID = model.Rol_ID;

                GiyimModel.SaveChanges();

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanıcı/Delete/5
        public ActionResult Delete(int id)
        {
            KULLANICILAR GoruntulenecekKullanici = GiyimModel.KULLANICILAR.Find(id);
            return View(GoruntulenecekKullanici);
        }

        // POST: Kullanıcı/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                KULLANICILAR silinecekKullanici = GiyimModel.KULLANICILAR.Find(id);

                GiyimModel.KULLANICILAR.Remove(silinecekKullanici);
                GiyimModel.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
