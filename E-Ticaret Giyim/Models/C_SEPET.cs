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
    
    public partial class C_SEPET
    {
        public int C_Sepet_ID { get; set; }
        public int C_Urun_ID { get; set; }
        public Nullable<int> C_Urun_miktar { get; set; }
        public int C_Kullanici_ID { get; set; }
        public string special1 { get; set; }
        public string special2 { get; set; }
        public string special3 { get; set; }
    }
}