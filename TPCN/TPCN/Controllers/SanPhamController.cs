using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPCN.Models;

namespace TPCN.Controllers
{
    public class SanPhamController : Controller
    {
        TPCNEntities db = new TPCNEntities();
        // GET: SanPham
        public ActionResult LoaiSP()
        {
            
            return View(db.LOAISPs.ToList());
        }
        public ActionResult CTLoai(int loai)
        {
            var l = db.SANPHAMs.Where(n => n.MALOAI == loai).ToList();
            return View(l);
        }
        public ActionResult CTSanPham(int sanpham)
        {
            ViewBag.TrangChu = "Chi Tiết Sản Phẩm";
            var sp = db.SANPHAMs.Where(n=>n.MASP==sanpham).ToList();
            return View(sp);
        }
        public ActionResult SanPhamKhac()
        {
            var spk = db.SANPHAMs.LayNgauNhien(4);
            return View(spk);
        }
    }
}