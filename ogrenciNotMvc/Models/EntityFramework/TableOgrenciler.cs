//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ogrenciNotMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class TableOgrenciler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TableOgrenciler()
        {
            this.TableNotlar = new HashSet<TableNotlar>();
        }
    
        public int ogrID { get; set; }
        public string ogrAd { get; set; }
        public string ogrSoyad { get; set; }
        public string ogrCinsiyet { get; set; }
        public Nullable<byte> ogrKulup { get; set; }
    
        public virtual TableKulupler TableKulupler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableNotlar> TableNotlar { get; set; }
    }
}
