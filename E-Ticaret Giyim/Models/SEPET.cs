//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Ticaret_Giyim.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SEPET
    {
        public int Sepet_ID { get; set; }
        public int Urun_ID { get; set; }
        public int Kullanici_ID { get; set; }
        public Nullable<int> Urun_Adet { get; set; }
    
        public virtual KULLANICILAR KULLANICILAR { get; set; }
        public virtual URUNLER URUNLER { get; set; }
    }
}
