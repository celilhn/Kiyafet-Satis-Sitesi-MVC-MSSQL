using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Ticaret_Giyim.Models;

namespace E_Ticaret_Giyim
{
    public class ViewModel
    {
        E_GIYIM_DBOEntities4 GiyimModel = new E_GIYIM_DBOEntities4();
        public IEnumerable<KATEGORILER> Categories { get; set; }
        public IEnumerable<ALT_KATEGORILER> SubCategories { get; set; }
        public IEnumerable<URUNLER> Products { get; set; }
        public IEnumerable<CINSIYET> Genders { get; set; }
        public IEnumerable<KULLANICILAR> Users { get; set; }
        public IEnumerable<SEPET> Sepets { get; set; }
        public int kullaniciID { get; set; }

    }
}