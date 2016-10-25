using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPCN.Models;

namespace TPCN.Models
{
    public class GioHang
    {
        TPCNEntities db = new TPCNEntities();
        public int iMaSP { set; get; }
        public string sTENSP { set; get; }
        public string sHINHANH { set; get; }
        public Double dDONGIA { set; get; }
        public int iSOLUONG { set; get; }
        public Double dTHANHTIEN
        {
            get { return iSOLUONG * dDONGIA; }
        }
        public GioHang(int masp)
        {
            iMaSP = masp;
            SANPHAM sanpham = db.SANPHAM.Single(n => n.MASP == iMaSP);
            sTENSP = sanpham.TENSP;
            sHINHANH = sanpham.HINHANH;
            dDONGIA = double.Parse(sanpham.DONGIA.ToString());
            iSOLUONG = 1;
        }
    }
}