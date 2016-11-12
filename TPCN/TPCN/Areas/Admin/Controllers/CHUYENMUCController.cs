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
    public class CHUYENMUCController : Controller
    {
        private TPCNEntities db = new TPCNEntities();

        // GET: Admin/CHUYENMUC
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.CHUYENMUCs.ToList().ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/CHUYENMUC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENMUC cHUYENMUC = db.CHUYENMUCs.Find(id);
            if (cHUYENMUC == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENMUC);
        }

        // GET: Admin/CHUYENMUC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CHUYENMUC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MACM,TENCM,URLCM")] CHUYENMUC cHUYENMUC)
        {
            if (ModelState.IsValid)
            {
                db.CHUYENMUCs.Add(cHUYENMUC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHUYENMUC);
        }

        // GET: Admin/CHUYENMUC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENMUC cHUYENMUC = db.CHUYENMUCs.Find(id);
            if (cHUYENMUC == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENMUC);
        }

        // POST: Admin/CHUYENMUC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MACM,TENCM,URLCM")] CHUYENMUC cHUYENMUC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUYENMUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHUYENMUC);
        }

        // GET: Admin/CHUYENMUC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENMUC cHUYENMUC = db.CHUYENMUCs.Find(id);
            if (cHUYENMUC == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENMUC);
        }

        // POST: Admin/CHUYENMUC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHUYENMUC cHUYENMUC = db.CHUYENMUCs.Find(id);
            db.CHUYENMUCs.Remove(cHUYENMUC);
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
