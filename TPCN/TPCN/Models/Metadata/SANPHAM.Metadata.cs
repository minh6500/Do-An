using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiet ke Metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TPCN.Models
{
    [MetadataTypeAttribute(typeof(SANPHAMMetadata))]
    public partial class SANPHAM
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class SANPHAMMetadata
        {
            [Display(Name ="Mã Sản Phẩm")]
            public int MASP { get; set; }

            [Display(Name = "Tên Sản Phẩm")]
            [Required(ErrorMessage = "Vui Lòng Không Được Để Trống!")]
            public string TENSP { get; set; }

            [Display(Name = "Mô Tả")]
            [Required(ErrorMessage = "Vui Lòng Không Được Để Trống!")]
            public string MOTA { get; set; }

            [Display(Name = "Hình Ảnh")]
            [Required(ErrorMessage = "Vui Lòng Không Được Để Trống!")]
            public string HINHANH { get; set; }

            [Display(Name = "Ngày Cập Nhật")]
            [Required(ErrorMessage = "Vui Lòng Không Được Để Trống!")]
            [DataType(DataType.Date)]
            public System.DateTime NGAYCAPNHAT { get; set; }

            [Display(Name = "Đơn Giá")]
            [Required(ErrorMessage = "Vui Lòng Không Được Để Trống!")]
            public int DONGIA { get; set; }

            [Display(Name = "Khuyến Mãi")]
            public Nullable<int> KHUYENMAI { get; set; }

            [Display(Name = "Thanh Toán Trực Tuyến")]
            public string THANHTOANTRUCTUYEN { get; set; }

            [Display(Name = "Đường dẫn thân thiện")]
            public string URL { get; set; }
        }
    }
}