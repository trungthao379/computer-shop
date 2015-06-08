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
    public class ManageGraphicController : Controller
    {
        private LaptopEntities db = new LaptopEntities();

        // GET: /ManageGraphic/
        public ActionResult Index()
        {
            return View(db.Graphics.ToList());
        }

        // GET: /ManageGraphic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graphic graphic = db.Graphics.Find(id);
            if (graphic == null)
            {
                return HttpNotFound();
            }
            return View(graphic);
        }

        // GET: /ManageGraphic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ManageGraphic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "graphicID,graphicName,manufacturer,graphicType,isNoLonger,creator,createDate,updator,updateDate")] Graphic graphic)
        {
            if (ModelState.IsValid)
            {
                db.Graphics.Add(graphic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(graphic);
        }

        // GET: /ManageGraphic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graphic graphic = db.Graphics.Find(id);
            if (graphic == null)
            {
                return HttpNotFound();
            }
            return View(graphic);
        }

        // POST: /ManageGraphic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "graphicID,graphicName,manufacturer,graphicType,isNoLonger,creator,createDate,updator,updateDate")] Graphic graphic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graphic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(graphic);
        }

        // GET: /ManageGraphic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graphic graphic = db.Graphics.Find(id);
            if (graphic == null)
            {
                return HttpNotFound();
            }
            return View(graphic);
        }

        // POST: /ManageGraphic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Graphic graphic = db.Graphics.Find(id);
            db.Graphics.Remove(graphic);
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
