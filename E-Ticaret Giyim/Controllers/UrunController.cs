using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret_Giyim.Models;
using PagedList;

namespace E_Ticaret_Giyim.Controllers
{
    public class UrunController : Controller
    {
        E_GIYIM_DBOEntities4 GiyimModel = new E_GIYIM_DBOEntities4();
        // GET: Urun
        public ActionResult Index(int? SayfaNo = 1)
        {
            int _sayfaNo = SayfaNo ?? 1;
            var UrunList = GiyimModel.URUNLER.OrderByDescending(m => m.Urun_ID).ToPagedList<URUNLER>(_sayfaNo, 12);
            //List<URUNLER> UrunList = GiyimModel.URUNLER.ToList();
            return View(UrunList);

        }

        // GET: Urun/Details/5
        public ActionResult Details(int id)
        {
            URUNLER GoruntulenecekUrun = GiyimModel.URUNLER.Find(id);
            return View(GoruntulenecekUrun);
        }

        // GET: Urun/Create
        public ActionResult Create()
        {
            ViewBag.AltKategoriler = new SelectList(GiyimModel.ALT_KATEGORILER, "Alt_Kategoriler_ID", "Alt_Kategoriler_Ad");
            ViewBag.AltKategorilerKadın = new SelectList(GiyimModel.ALT_KATEGORILER.Where(s => s.CinsiyetID == 2), "Alt_Kategoriler_ID", "Alt_Kategoriler_Ad");
            return View();
        }

        // POST: Urun/Create
        [HttpPost]
        public ActionResult Create(URUNLER model, HttpPostedFileBase file)
        {
            try
            {
                if (file == null)
                {
                    var InputFileName = Path.GetFileName(model.Urun_Fotograf);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    ViewBag.UploadStatus = " file uploaded successfully.";
                    //string ResimAdi = System.IO.Path.GetFileName(file.FileName);
                    //string adres = Server.MapPath("~/images/" + ResimAdi);
                }
                URUNLER yeniUrun = new URUNLER();
                    yeniUrun.Urun_Ad = model.Urun_Ad;
                    yeniUrun.Urun_Beden = model.Urun_Beden;
                    yeniUrun.Urun_Fiyat = model.Urun_Fiyat;
                    yeniUrun.Urun_Fotograf = model.Urun_Fotograf;
                    yeniUrun.Urun_Aciklama = model.Urun_Aciklama;
                    yeniUrun.Urun_Marka = model.Urun_Marka;
                    yeniUrun.Urun_Renk = model.Urun_Renk;
                    yeniUrun.Alt_Kategori_ID = model.Alt_Kategori_ID;

                    GiyimModel.URUNLER.Add(yeniUrun);
                    GiyimModel.SaveChanges();
                    return RedirectToAction("Index");
                //}
                //else
                //    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Urun/Edit/5
        public ActionResult Edit(int id)
        {
            URUNLER GoruntulenecekUrun = GiyimModel.URUNLER.Find(id);
            return View(GoruntulenecekUrun);
        }

        // POST: Urun/Edit/5
        [HttpPost]
        public ActionResult Edit(URUNLER model)
        {
            try
            {
                URUNLER duzenlenecekUrun = GiyimModel.URUNLER.Find(model.Urun_ID);
                duzenlenecekUrun.Urun_Ad = model.Urun_Ad;
                duzenlenecekUrun.Urun_Beden = model.Urun_Beden;
                duzenlenecekUrun.Urun_Fiyat = model.Urun_Fiyat;
                duzenlenecekUrun.Urun_Fotograf = model.Urun_Fotograf;
                duzenlenecekUrun.Urun_Aciklama = model.Urun_Aciklama;
                duzenlenecekUrun.Urun_Marka = model.Urun_Marka;
                duzenlenecekUrun.Urun_Renk = model.Urun_Renk;
                duzenlenecekUrun.Alt_Kategori_ID = model.Alt_Kategori_ID;

                GiyimModel.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Urun/Delete/5
        public ActionResult Delete(int id)
        {
            URUNLER GoruntulenecekUrun = GiyimModel.URUNLER.Find(id);
            return View(GoruntulenecekUrun);
        }

        // POST: Urun/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                URUNLER silinecekUrun = GiyimModel.URUNLER.Find(id);

                GiyimModel.URUNLER.Remove(silinecekUrun);
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
