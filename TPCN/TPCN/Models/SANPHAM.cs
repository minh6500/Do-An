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
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.CTDDH = new HashSet<CTDDH>();
        }
    
        public int MASP { get; set; }
        public string TENSP { get; set; }
        public string MOTA { get; set; }
        public string HINHANH { get; set; }
        public System.DateTime NGAYCAPNHAT { get; set; }
        public int DONGIA { get; set; }
        public Nullable<int> KHUYENMAI { get; set; }
        public int MALOAI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDDH> CTDDH { get; set; }
        public virtual LOAISP LOAISP { get; set; }
    }
}
