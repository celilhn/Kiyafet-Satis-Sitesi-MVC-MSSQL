using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret_Giyim.Models;

namespace E_Ticaret_Giyim.Controllers
{
    public class KategoriController : Controller
    {
        E_GIYIM_DBOEntities4 GiyimModel = new E_GIYIM_DBOEntities4();
        // GET: Kategori
        public ActionResult Index()
        {
            List<ALT_KATEGORILER> kategoriList = GiyimModel.ALT_KATEGORILER.ToList();
            return View(kategoriList);
        }

        // GET: Kategori/Details/5
        public ActionResult Details(int id)
        {
            ALT_KATEGORILER GoruntulenecekKategori = GiyimModel.ALT_KATEGORILER.Find(id);
            return View(GoruntulenecekKategori);
        }

        // GET: Kategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategori/Create
        [HttpPost]
        public ActionResult Create(ALT_KATEGORILER model)
        {
            try
            {
                ALT_KATEGORILER yeniKategori = new ALT_KATEGORILER();
                yeniKategori.Alt_Kategoriler_Ad = model.Alt_Kategoriler_Ad;
                yeniKategori.Resim_Yol = model.Resim_Yol;
                yeniKategori.CinsiyetID = model.CinsiyetID;
                yeniKategori.Kategori_ID = model.Kategori_ID;

                GiyimModel.ALT_KATEGORILER.Add(yeniKategori);
                GiyimModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(int id)
        {
            ALT_KATEGORILER duzenlenecekKategori = GiyimModel.ALT_KATEGORILER.Find(id);
            return View(duzenlenecekKategori);
        }

        // POST: Kategori/Edit/5
        [HttpPost]
        public ActionResult Edit(ALT_KATEGORILER model)
        {
            try
            {
                ALT_KATEGORILER duzenlenecekKategori = GiyimModel.ALT_KATEGORILER.Find(model.Alt_Kategoriler_ID);
                duzenlenecekKategori.Alt_Kategoriler_Ad = model.Alt_Kategoriler_Ad;
                duzenlenecekKategori.CinsiyetID = model.CinsiyetID;
                duzenlenecekKategori.Resim_Yol = model.Resim_Yol;
                duzenlenecekKategori.Kategori_ID = model.Kategori_ID;

                GiyimModel.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kategori/Delete/5
        public ActionResult Delete(int id)
        {
            ALT_KATEGORILER silinecekKategori = GiyimModel.ALT_KATEGORILER.Find(id);
            return View(silinecekKategori);
        }

        // POST: Kategori/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ALT_KATEGORILER silinecekKategori = GiyimModel.ALT_KATEGORILER.Find(id);

                GiyimModel.ALT_KATEGORILER.Remove(silinecekKategori);
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
