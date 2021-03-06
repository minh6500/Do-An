﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPCN.Models;

namespace TPCN.Controllers
{
    public class HomeController : Controller
    {
        TPCNEntities db = new TPCNEntities();
        // GET: Home
        private List<SANPHAM> SanPhamMoi(int count)
        {
            return db.SANPHAMs.OrderByDescending(a => a.NGAYCAPNHAT).Take(count).ToList();
        }

        public ActionResult Index()
        {
            ViewBag.TrangChu = "Trang Chủ";
            var spmoi = SanPhamMoi(4);
            return View(spmoi);
        }
        
    }
}