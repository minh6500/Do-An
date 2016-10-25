using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPCN.Models;

namespace TPCN.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        TPCNEntities db = new TPCNEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            ViewBag.DangNhap = "Đăng Nhập";
            return PartialView();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KHACHHANG kh)
        {
            var hoten = collection["Fullname"];
            var taikhoan = collection["Username"];
            var matkhau = collection["Password"];
            var email = collection["Email"];
            var sdt = collection["Phone"];
            var diachi = collection["Address"];
            kh.DIACHI = diachi;
            kh.TENKH = hoten;
            kh.USERNAME = taikhoan;
            kh.EMAIL = email;
            kh.SDT = sdt;
            kh.PASS = matkhau;
            ViewBag.ThongBao = "Đăng ký thành công";
            return this.DangKy();

        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            ViewBag.DangNhap = "Đăng Nhập";
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var taikhoan = collection["Username"];
            var matkhau = collection["Password"];
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.USERNAME == taikhoan && n.PASS == matkhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công!";
                Session["User"] = kh;
                ViewBag.KhachHang = kh.TENKH;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu sai!";
            }
            return View();
        }
        public ActionResult Thoat()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");

        }
        public ActionResult ThongTinTaiKhoan()
        {
            var kh = (KHACHHANG)Session["User"];
            return View(kh);
        }
           
    }
}