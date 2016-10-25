﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPCN.Models;

namespace TPCN.Areas.Admin.Controllers
{
    public class SANPHAMController : Controller
    {
        private TPCNEntities db = new TPCNEntities();

        // GET: Admin/SANPHAM
        public ActionResult Index()
        {
            var sANPHAMs = db.SANPHAM.Include(s => s.LOAISP);
            return View(sANPHAMs.ToList());
        }

        // GET: Admin/SANPHAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAM.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAM/Create
        public ActionResult Create()
        {
            ViewBag.MALOAI = new SelectList(db.LOAISP, "MALOAI", "TENLOAI");
            return View();
        }

        // POST: Admin/SANPHAM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MASP,TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAM.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MALOAI = new SelectList(db.LOAISP, "MALOAI", "TENLOAI", sANPHAM.MALOAI);
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAM.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALOAI = new SelectList(db.LOAISP, "MALOAI", "TENLOAI", sANPHAM.MALOAI);
            return View(sANPHAM);
        }

        // POST: Admin/SANPHAM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASP,TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MALOAI = new SelectList(db.LOAISP, "MALOAI", "TENLOAI", sANPHAM.MALOAI);
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAM.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: Admin/SANPHAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANPHAM sANPHAM = db.SANPHAM.Find(id);
            db.SANPHAM.Remove(sANPHAM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
