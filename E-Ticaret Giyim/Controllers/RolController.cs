using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret_Giyim.Models;

namespace E_Ticaret_Giyim.Controllers
{
    public class RolController : Controller
    {
        E_GIYIM_DBOEntities4 GiyimModel = new E_GIYIM_DBOEntities4();
        // GET: Rol
        public ActionResult Index()
        {
            List<ROL> rolList = GiyimModel.ROL.ToList();
            return View(rolList);
        }

        // GET: Rol/Details/5
        public ActionResult Details(int id)
        {
            ROL GoruntulenecekRol = GiyimModel.ROL.Find(id);
            return View(GoruntulenecekRol);
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        [HttpPost]
        public ActionResult Create(ROL model)
        {
            try
            {
                ROL yeniRol = new ROL();
                yeniRol.Rol_ID = model.Rol_ID;
                yeniRol.Rol_Ad = model.Rol_Ad;

                GiyimModel.ROL.Add(yeniRol);
                GiyimModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rol/Edit/5
        public ActionResult Edit(int id)
        {
            ROL GoruntulenecekRol = GiyimModel.ROL.Find(id);
            return View(GoruntulenecekRol);
        }

        // POST: Rol/Edit/5
        [HttpPost]
        public ActionResult Edit(ROL model)
        {
            try
            {
                ROL duzenlenecekRol = GiyimModel.ROL.Find(model.Rol_ID);
                duzenlenecekRol.Rol_ID = model.Rol_ID;
                duzenlenecekRol.Rol_Ad = model.Rol_Ad;

                GiyimModel.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rol/Delete/5
        public ActionResult Delete(int id)
        {
            ROL GoruntulenecekRol = GiyimModel.ROL.Find(id);
            return View(GoruntulenecekRol);
        }

        // POST: Rol/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ROL silinecekRol = GiyimModel.ROL.Find(id);

                GiyimModel.ROL.Remove(silinecekRol);
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
