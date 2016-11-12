using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPCN.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace TPCN.Areas.Admin.Controllers
{
    public class SANPHAMsController : Controller
    {
        private TPCNEntities db = new TPCNEntities();

        // GET: Admin/SANPHAM
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var sANPHAMs = db.SANPHAMs.Include(s => s.LOAISP);
            return View(sANPHAMs.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/SANPHAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAM/Create
        public ActionResult Create()
        {
            ViewBag.MALOAI = new SelectList(db.LOAISPs, "MALOAI", "TENLOAI");
            return View();
        }

        // POST: Admin/SANPHAM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "MASP,TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI,THANHTOANTRUCTUYEN,URL")] SANPHAM sANPHAM, HttpPostedFileBase fileUpload)
        {
            ViewBag.MALOAI = new SelectList(db.LOAISPs, "MALOAI", "TENLOAI", sANPHAM.MALOAI);
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Vui lòng nhập hình ảnh";
                return View();
            }
            //Lưu Tên File
            var fileName = Path.GetFileName(fileUpload.FileName);
            //Lưu đường dẫn của file
            var path = Path.Combine(Server.MapPath("~/HinhSP"), fileName);
            //Kiểm tra hình ảnh
            fileUpload.SaveAs(path);
            sANPHAM.HINHANH = fileUpload.FileName;
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALOAI = new SelectList(db.LOAISPs, "MALOAI", "TENLOAI", sANPHAM.MALOAI);
            return View(sANPHAM);
        }

        // POST: Admin/SANPHAM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MASP,TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI,THANHTOANTRUCTUYEN,URL")] SANPHAM sANPHAM, HttpPostedFileBase fileUpload)
        {
            ViewBag.MALOAI = new SelectList(db.LOAISPs, "MALOAI", "TENLOAI", sANPHAM.MALOAI);
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Vui lòng nhập hình ảnh";
                return View();
            }
            //Lưu Tên File
            var fileName = Path.GetFileName(fileUpload.FileName);
            //Lưu đường dẫn của file
            var path = Path.Combine(Server.MapPath("~/HinhSP"), fileName);
            //Kiểm tra hình ảnh
            fileUpload.SaveAs(path);
            sANPHAM.HINHANH = fileUpload.FileName;
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
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
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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
