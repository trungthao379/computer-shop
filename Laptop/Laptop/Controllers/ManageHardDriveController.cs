using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laptop.Models;
using Laptop;

namespace Laptop.Controllers
{
    public class ManageHardDriveController : Controller
    {
        private LaptopEntities db = new LaptopEntities();

        // GET: /ManageHardDrive/
        public ActionResult Index()
        {
            return View(db.HardDrives.ToList());
        }

        // GET: /ManageHardDrive/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HardDrive harddrive = db.HardDrives.Find(id);
            if (harddrive == null)
            {
                return HttpNotFound();
            }
            return View(harddrive);
        }

        // GET: /ManageHardDrive/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ManageHardDrive/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hardDriveID,hardDriveName,manufacturer,diskSpace,hardDriveType,isNoLonger,creator,createDate,updator,updateDate")] HardDrive harddrive)
        {
            if (ModelState.IsValid)
            {
                db.HardDrives.Add(harddrive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(harddrive);
        }

        // GET: /ManageHardDrive/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HardDrive harddrive = db.HardDrives.Find(id);
            if (harddrive == null)
            {
                return HttpNotFound();
            }
            return View(harddrive);
        }

        // POST: /ManageHardDrive/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hardDriveID,hardDriveName,manufacturer,diskSpace,hardDriveType,isNoLonger,creator,createDate,updator,updateDate")] HardDrive harddrive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(harddrive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(harddrive);
        }

        // GET: /ManageHardDrive/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HardDrive harddrive = db.HardDrives.Find(id);
            if (harddrive == null)
            {
                return HttpNotFound();
            }
            return View(harddrive);
        }

        // POST: /ManageHardDrive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HardDrive harddrive = db.HardDrives.Find(id);
            db.HardDrives.Remove(harddrive);
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
