//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPCN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            this.CTDDHs = new HashSet<CTDDH>();
        }
    
        public int MAD { get; set; }
        public System.DateTime NGAYDAT { get; set; }
        public string TENDAIDIEN { get; set; }
        public string SDT { get; set; }
        public string DIACHIGIAO { get; set; }
        public Nullable<bool> TINHTRANGTHANHTOAN { get; set; }
        public Nullable<bool> TINHTRANGGIAOHANG { get; set; }
        public Nullable<int> MAKH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDDH> CTDDHs { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
