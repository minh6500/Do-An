using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPCN.Models
{
    public class GioHang
    {
        TPCNEntities db = new TPCNEntities();
        public int iMASP { set; get; }
        public string sTENSP { set; get; }
        public string sHINHANH { set; get; }
        public double dDONGIA { set; get; }
        public int iSOLUONG { set; get; }
        public double dTHANHTIEN
        {
            get { return iSOLUONG * dDONGIA; }
        }
        public GioHang(int MASP)
        {
            iMASP = MASP;
            SANPHAM sanpham = db.SANPHAMs.Single(n => n.MASP == iMASP);
            sTENSP = sanpham.TENSP;
            sHINHANH = sanpham.HINHANH;
            dDONGIA = double.Parse(sanpham.DONGIA.ToString());
            iSOLUONG = 1;
        }
    }
}