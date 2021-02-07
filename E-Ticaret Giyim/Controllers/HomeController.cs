using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using E_Ticaret_Giyim.Models;
using PagedList;

namespace E_Ticaret_Giyim.Controllers
{
    public class HomeController : Controller
    {
        E_GIYIM_DBOEntities4 GiyimModel = new E_GIYIM_DBOEntities4();
        
        public ActionResult Index(int item = 0, int kategoriItem = 0, int? SayfaNo = 1)
        {
            ViewData["SayfaNo"] = SayfaNo ?? 1;
            ViewData["item"] = item;
            ViewData["kategoriItem"] = kategoriItem;
            ViewModel viewModel = new ViewModel();
            viewModel.Categories = GiyimModel.KATEGORILER;
            viewModel.SubCategories = GiyimModel.ALT_KATEGORILER;
            viewModel.Products = GiyimModel.URUNLER;
            viewModel.Genders = GiyimModel.CINSIYET;

            return View(viewModel);
            
        }

        //GET: KayitOl
        public ActionResult KayitOl()
        {
            ViewBag.Cinsiyet = new SelectList(GiyimModel.CINSIYET, "Cinsiyet_ID", "Cinsiyet_Ad");
            ViewBag.Cinsiyet = new SelectList(GiyimModel.CINSIYET, "Cinsiyet_ID", "Cinsiyet_Ad");
            ViewModel viewModel = new ViewModel();
            viewModel.Categories = GiyimModel.KATEGORILER;
            viewModel.SubCategories = GiyimModel.ALT_KATEGORILER;
            viewModel.Products = GiyimModel.URUNLER;
            viewModel.Genders = GiyimModel.CINSIYET;
            return View(viewModel);
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KayitOl(KULLANICILAR _Kullanici)
        {
            if (ModelState.IsValid)
            {
                var check = GiyimModel.KULLANICILAR.FirstOrDefault(s => s.Kullanici_Email == _Kullanici.Kullanici_Email);
                if (check == null)
                {
                    _Kullanici.Kullanici_Sifre = GetMD5(_Kullanici.Kullanici_Sifre);
                    _Kullanici.Rol_ID = 1;
                    GiyimModel.Configuration.ValidateOnSaveEnabled = false;
                    GiyimModel.KULLANICILAR.Add(_Kullanici);
                    GiyimModel.SaveChanges();
                    return RedirectToAction("Giris");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }

            }
            return View();

        }

        //GET: Giris
        public ActionResult Giris()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Categories = GiyimModel.KATEGORILER;
            viewModel.SubCategories = GiyimModel.ALT_KATEGORILER;
            viewModel.Products = GiyimModel.URUNLER;
            viewModel.Genders = GiyimModel.CINSIYET;
            viewModel.Users = GiyimModel.KULLANICILAR;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Giris(KULLANICILAR _kullanici)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(_kullanici.Kullanici_Sifre);
                var data = GiyimModel.KULLANICILAR.Where(s => s.Kullanici_Email.Equals(_kullanici.Kullanici_Email) && s.Kullanici_Sifre.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().Kullanici_Ad;
                    Session["Email"] = data.FirstOrDefault().Kullanici_Email;
                    Session["idUser"] = data.FirstOrDefault().Kullanici_ID;
                    Session["Rol"] = data.FirstOrDefault().Rol_ID;
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Giris");
                }
            }
            return View();
        }

        //GET: UrunDetay
        public ActionResult UrunDetay(int id)
        {
            URUNLER detayUrun = GiyimModel.URUNLER.Find(id);
            TempData["Id"] = detayUrun.Urun_ID;
            TempData["Ad"] = detayUrun.Urun_Ad;
            TempData["Fiyat"] = detayUrun.Urun_Fiyat;
            TempData["Marka"] = detayUrun.Urun_Marka;
            TempData["Aciklama"] = detayUrun.Urun_Aciklama;
            TempData["Beden"] = detayUrun.Urun_Beden;
            TempData["Aciklama"] = detayUrun.Urun_Aciklama;
            TempData["ResimYol"] = detayUrun.Urun_Fotograf;
            TempData["Aciklama"] = detayUrun.Urun_Aciklama;
            TempData["Marka"] = detayUrun.Urun_Marka;
            ViewModel viewModel = new ViewModel();
            viewModel.Categories = GiyimModel.KATEGORILER;
            viewModel.SubCategories = GiyimModel.ALT_KATEGORILER;
            viewModel.Products = GiyimModel.URUNLER;
            viewModel.Genders = GiyimModel.CINSIYET;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UrunDetay()
        {
            return RedirectToAction("Giris");
        }

        //GET: Iletisim
        public ActionResult Iletisim()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Categories = GiyimModel.KATEGORILER;
            viewModel.SubCategories = GiyimModel.ALT_KATEGORILER;
            viewModel.Products = GiyimModel.URUNLER;
            viewModel.Genders = GiyimModel.CINSIYET;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Iletisim(int id)
        {
            return View();
        }

        //PartialView: Urunler
        public ActionResult Urunler(int item = 0, int kategoriItem = 0, int? SayfaNo = 1)
        {
            int _sayfaNo = SayfaNo ?? 1;
            var UrunListesi = GiyimModel.URUNLER.OrderByDescending(m => m.Urun_ID).ToPagedList<URUNLER>(_sayfaNo, 12);

            if (kategoriItem == 0)
                if (item == 0)
                    UrunListesi = GiyimModel.URUNLER.OrderByDescending(m => m.Urun_ID).ToPagedList<URUNLER>(_sayfaNo, 12);
                else
                    UrunListesi = GiyimModel.URUNLER.Where(s => s.Alt_Kategori_ID == item).OrderByDescending(m => m.Urun_ID).ToPagedList<URUNLER>(_sayfaNo, 12);
            else
                UrunListesi = GiyimModel.URUNLER.Where(s => s.ALT_KATEGORILER.Kategori_ID == kategoriItem).OrderByDescending(m => m.Urun_ID).ToPagedList<URUNLER>(_sayfaNo, 12);

            return PartialView(UrunListesi);
        }

        //PartialView: _GirisSayfasiPartial
        public ActionResult _GirisSayfasiPartial()
        {
            var MusteriListesi = GiyimModel.KULLANICILAR;
            return PartialView();
        }

        //PartialView: _KayitSayfasiPartial
        public ActionResult _KayitSayfasiPartial()
        {
            ViewBag.Cinsiyet = new SelectList(GiyimModel.CINSIYET, "Cinsiyet_ID", "Cinsiyet_Ad");
            return PartialView();
        }

        //GET: Sepet
        public ActionResult Sepet(int id)
        {
            if (Session["FullName"] != null)
            {
                ViewData["Id2"] = id;
                ViewModel viewModel = new ViewModel();
                viewModel.Categories = GiyimModel.KATEGORILER;
                viewModel.SubCategories = GiyimModel.ALT_KATEGORILER;
                viewModel.Products = GiyimModel.URUNLER;
                viewModel.Genders = GiyimModel.CINSIYET;
                viewModel.Users = GiyimModel.KULLANICILAR;
                return View(viewModel);
            }
            else
                return RedirectToAction("Giris");
            
        }

        //GET: Cikis
        public ActionResult Cikis()
        {
            Session.Clear();//remove session
            return RedirectToAction("Giris");
        }

        //PartialView: _SepetPartial
        public ActionResult _SepetPartial(int id, bool ekle)
        {

            if(ekle)
            {
                SEPET yeniSepet = new SEPET();
                yeniSepet.Kullanici_ID = Convert.ToInt32(Session["idUser"]);
                yeniSepet.Urun_ID = id;
                yeniSepet.Urun_Adet = 1;
                var SepetListesi = GiyimModel.SEPET.Where(s => s.Kullanici_ID == yeniSepet.Kullanici_ID);
                GiyimModel.SEPET.Add(yeniSepet);
                GiyimModel.SaveChanges();

                ViewModel viewModel = new ViewModel();
                viewModel.Products = GiyimModel.URUNLER;
                viewModel.Sepets = SepetListesi;
                viewModel.kullaniciID = Convert.ToInt32(Session["idUser"]);
                return PartialView(viewModel);
            }
            else
            {
                ViewData["_urunId"] = id;
                int kk = Convert.ToInt32(Session["idUser"]);
                ViewModel viewModel = new ViewModel();
                viewModel.Products = GiyimModel.URUNLER;
                var SepetListesi = GiyimModel.SEPET.Where(s => s.Kullanici_ID == kk);
                viewModel.Sepets = SepetListesi;
                return PartialView(viewModel);
            }

        }

        //Function
        private string GetMD5(string kullanici_Sifre)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(kullanici_Sifre);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        //GET: Cikis
        //public ActionResult SatinAl(int id, int para)
        public ActionResult SatinAl(int urunId,int sepetId, int kullaniciId, int para,bool sepet)
        {
            if(sepet)
            {
                SEPET silinecekSepet = GiyimModel.SEPET.Find(sepetId);
                if (silinecekSepet != null)
                {
                    GiyimModel.SEPET.Remove(silinecekSepet);
                    GiyimModel.SaveChanges();
                }
                    
                return RedirectToAction("Sepet", new { @id = urunId, ekle=false });
            }
            else
            {
                KULLANICILAR duzenlenecekBakiye = GiyimModel.KULLANICILAR.Find(kullaniciId);
                if (duzenlenecekBakiye.Bakiye == null)
                    return RedirectToAction("Index");
                if (para > duzenlenecekBakiye.Bakiye)
                    return RedirectToAction("Index");
                else
                {
                    duzenlenecekBakiye.Bakiye = duzenlenecekBakiye.Bakiye - para;
                    GiyimModel.SaveChanges();
                    return RedirectToAction("Sepet", new { @id=urunId, ekle=false });
                }
            }


            
        }

        public ActionResult MesajGonder(string ad, string email, string konu, string mesaj)
        {
            var fromAddress = new MailAddress("...@gmail.com");
            var toAddress = new MailAddress("...@gmail.com");
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "password")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = konu, Body = mesaj })
                {
                    smtp.Send(message);
                    EMAIL _email = new EMAIL();
                    _email.Konu = konu;
                    _email.Mesaj = mesaj;
                    _email.Kullanici_ID = 0;
                    _email.Special1 = ad;
                    _email.Special2 = email;

                    GiyimModel.EMAIL.Add(_email);
                    GiyimModel.SaveChanges();
                }
            }
            return RedirectToAction("Iletisim");
         
        }

        public ActionResult SepettenUrunSil(int id,int urunID)
        {
            SEPET sepet = GiyimModel.SEPET.Find(id);

            GiyimModel.SEPET.Remove(sepet);
            GiyimModel.SaveChanges();

            return RedirectToAction("Sepet", urunID);
        }
    }
}