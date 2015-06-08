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

namespace Laptop.Models
{
    public class ManageScreenController : Controller
    {
        private LaptopEntities db = new LaptopEntities();

        // GET: /ManageScreen/
        public ActionResult Index()
        {
            return View(db.Screens.ToList());
        }

        // GET: /ManageScreen/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screen screen = db.Screens.Find(id);
            if (screen == null)
            {
                return HttpNotFound();
            }
            return View(screen);
        }

        // GET: /ManageScreen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ManageScreen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="screenID,screenName,manufacturer,size,touchScreen,resolution,isNoLonger,type,creator,createDate,updator,updateDate")] Screen screen)
        {
            if (ModelState.IsValid)
            {
                db.Screens.Add(screen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(screen);
        }

        // GET: /ManageScreen/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screen screen = db.Screens.Find(id);
            if (screen == null)
            {
                return HttpNotFound();
            }
            return View(screen);
        }

        // POST: /ManageScreen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="screenID,screenName,manufacturer,size,touchScreen,resolution,isNoLonger,type,creator,createDate,updator,updateDate")] Screen screen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(screen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(screen);
        }

        // GET: /ManageScreen/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screen screen = db.Screens.Find(id);
            if (screen == null)
            {
                return HttpNotFound();
            }
            return View(screen);
        }

        // POST: /ManageScreen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Screen screen = db.Screens.Find(id);
            db.Screens.Remove(screen);
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
