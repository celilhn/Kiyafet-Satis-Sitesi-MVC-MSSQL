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
    
    public partial class ALT_KATEGORILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALT_KATEGORILER()
        {
            this.URUNLER = new HashSet<URUNLER>();
        }
    
        public int Alt_Kategoriler_ID { get; set; }
        public string Alt_Kategoriler_Ad { get; set; }
        public string Resim_Yol { get; set; }
        public int Kategori_ID { get; set; }
        public int CinsiyetID { get; set; }
    
        public virtual CINSIYET CINSIYET { get; set; }
        public virtual KATEGORILER KATEGORILER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<URUNLER> URUNLER { get; set; }
    }
}
