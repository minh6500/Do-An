using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiet ke Metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TPCN.Models
{
    [MetadataTypeAttribute(typeof(LOAISPMetadata))]
    public partial class LOAISP
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class LOAISPMetadata
        {
            [Display(Name = "Loại Sản Phẩm")]
            [Required(ErrorMessage = "Vui lòng không được để trống!")]
            public string TENLOAI { get; set; }

            [Display(Name = "Đường Dẫn Thân Thiện")]
            public string URLLOAISP { get; set; }
        }
    }
}