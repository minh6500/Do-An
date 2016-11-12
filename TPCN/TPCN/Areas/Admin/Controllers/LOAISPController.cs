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

namespace TPCN.Areas.Admin.Controllers
{
    public class LOAISPController : Controller
    {
        private TPCNEntities db = new TPCNEntities();

        // GET: Admin/LOAISP
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var lOAISPs = db.LOAISPs.Include(l => l.CHUYENMUC);
            return View(lOAISPs.ToList().ToPagedList(pageNumber,pageSize));
        }



        // GET: Admin/LOAISP/Create
        public ActionResult Create()
        {
            ViewBag.MACM = new SelectList(db.CHUYENMUCs, "MACM", "TENCM");
            return View();
        }

        // POST: Admin/LOAISP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOAI,TENLOAI,MACM,URLLOAISP")] LOAISP lOAISP)
        {
            if (ModelState.IsValid)
            {
                db.LOAISPs.Add(lOAISP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MACM = new SelectList(db.CHUYENMUCs, "MACM", "TENCM", lOAISP.MACM);
            return View(lOAISP);
        }

        // GET: Admin/LOAISP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = db.LOAISPs.Find(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACM = new SelectList(db.CHUYENMUCs, "MACM", "TENCM", lOAISP.MACM);
            return View(lOAISP);
        }

        // POST: Admin/LOAISP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOAI,TENLOAI,MACM,URLLOAISP")] LOAISP lOAISP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAISP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MACM = new SelectList(db.CHUYENMUCs, "MACM", "TENCM", lOAISP.MACM);
            return View(lOAISP);
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
