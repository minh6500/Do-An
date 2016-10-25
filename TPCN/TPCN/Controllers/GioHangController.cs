using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPCN.Models;

namespace TPCN.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        TPCNEntities db = new TPCNEntities();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;

            }
            return lstGioHang;

        }
        public ActionResult ThemGioHang(int iMASP, string strURL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.Find(n => n.iMaSP == iMASP);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMASP);
                lstGioHang.Add(sanpham);
                return Redirect(strURL);

            }
            else
            {
                sanpham.iSOLUONG++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSOLUONG);

            }
            return iTongSoLuong;
        }

        private double TongTien()
        {
            double iTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongTien = lstGioHang.Sum(n => n.dTHANHTIEN);

            }
            return iTongTien;

        }
        public ActionResult GioHang()
        {
            
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang.Count == 0)
            {
                ViewBag.GioHang = "Giỏ Hàng Rỗng!!";
                return View();

            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
        public ActionResult CapNhatGioHang(int iMASP,FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSP == iMASP);
            if(sanpham!=null)
            {
                sanpham.iSOLUONG = int.Parse(f["txtSOLUONG"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang(int iMASP)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSP == iMASP);
            if(sanpham!=null)
            {
                lstGioHang.RemoveAll(n => n.iMaSP == iMASP);
                return RedirectToAction("GioHang");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("GioHang");
        }
    }
}