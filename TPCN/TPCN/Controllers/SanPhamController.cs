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
            return View(db.LOAISP.ToList());
        }
        public ActionResult CTLoai(int loai)
        {
            var l = db.SANPHAM.Where(n => n.MALOAI == loai).ToList();
            return View(l);
        }
        public ActionResult CTSanPham(int sanpham)
        {
            var sp = db.SANPHAM.Where(n=>n.MASP==sanpham).ToList();
            return View(sp);
        }
    }
}