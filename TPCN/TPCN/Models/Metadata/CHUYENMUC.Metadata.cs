using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiet ke Metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TPCN.Models
{
    [MetadataTypeAttribute(typeof(CHUYENMUCMetadata))]
    public partial class CHUYENMUC
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class CHUYENMUCMetadata
        {
            [Display(Name = "Mã Chuyên Mục")]            
            public int MACM { get; set; }

            [Display(Name = "Tên Chuyên Mục")]
            [Required(ErrorMessage = "Vui Lòng Không Được Để Trống!")]
            public string TENCM { get; set; }

            [Display(Name = "Đường Dẫn Thân Thiện")]
            public string URLCM { get; set; }
        }
    }
}