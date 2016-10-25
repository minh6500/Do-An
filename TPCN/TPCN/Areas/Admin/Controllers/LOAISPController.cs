using System;
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
    public class LOAISPController : Controller
    {
        private TPCNEntities db = new TPCNEntities();

        // GET: Admin/LOAISP
        public ActionResult Index()
        {
            var lOAISPs = db.LOAISP.Include(l => l.CHUYENMUC);
            return View(lOAISPs.ToList());
        }

        // GET: Admin/LOAISP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = db.LOAISP.Find(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            return View(lOAISP);
        }

        // GET: Admin/LOAISP/Create
        public ActionResult Create()
        {
            ViewBag.MACM = new SelectList(db.CHUYENMUC, "MACM", "TENCM");
            return View();
        }

        // POST: Admin/LOAISP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOAI,TENLOAI,MACM")] LOAISP lOAISP)
        {
            if (ModelState.IsValid)
            {
                db.LOAISP.Add(lOAISP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MACM = new SelectList(db.CHUYENMUC, "MACM", "TENCM", lOAISP.MACM);
            return View(lOAISP);
        }

        // GET: Admin/LOAISP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = db.LOAISP.Find(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACM = new SelectList(db.CHUYENMUC, "MACM", "TENCM", lOAISP.MACM);
            return View(lOAISP);
        }

        // POST: Admin/LOAISP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOAI,TENLOAI,MACM")] LOAISP lOAISP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAISP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MACM = new SelectList(db.CHUYENMUC, "MACM", "TENCM", lOAISP.MACM);
            return View(lOAISP);
        }

        // GET: Admin/LOAISP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = db.LOAISP.Find(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            return View(lOAISP);
        }

        // POST: Admin/LOAISP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAISP lOAISP = db.LOAISP.Find(id);
            db.LOAISP.Remove(lOAISP);
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
