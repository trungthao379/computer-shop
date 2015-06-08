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
    public class ManageCPUController : Controller
    {
        private LaptopEntities db = new LaptopEntities();

        // GET: /ManageViXuLy/
        public ActionResult Index()
        {
            return View(db.CPUs.ToList());
        }

        // GET: /ManageViXuLy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cpu = db.CPUs.Find(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }
            return View(cpu);
        }

        // GET: /ManageViXuLy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ManageViXuLy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cpuID,cpuName,manufacturer,technology,cpuType,speed,isNoLonger")] CPU cpu)
        {
            if (ModelState.IsValid)
            {
                db.CPUs.Add(cpu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cpu);
        }

        // GET: /ManageViXuLy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cpu = db.CPUs.Find(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }
            return View(cpu);
        }

        // POST: /ManageViXuLy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cpuID,cpuName,manufacturer,technology,cpuType,speed,isNoLonger")] CPU cpu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cpu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cpu);
        }

        // GET: /ManageViXuLy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cpu = db.CPUs.Find(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }
            return View(cpu);
        }

        // POST: /ManageViXuLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CPU cpu = db.CPUs.Find(id);
            db.CPUs.Remove(cpu);
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
