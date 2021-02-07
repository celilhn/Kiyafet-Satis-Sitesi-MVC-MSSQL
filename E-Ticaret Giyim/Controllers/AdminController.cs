using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret_Giyim.Models;

namespace E_Ticaret_Giyim.Controllers
{
    public class AdminController : Controller
    {
        E_GIYIM_DBOEntities4 GiyimModel = new E_GIYIM_DBOEntities4();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Rol"].ToString() == "2")
            {
                return View();
            }
            else
                return RedirectToAction("Home/Index");
        }

    }
}
