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
    public class ManageProductController : Controller
    {
        private LaptopEntities db = new LaptopEntities();

        //Hiển thị sản phẩm
        public ActionResult Index(string Manufacturer)
        {
            // Đổ dữ liệu vào combobox search theo thương hiệu khi load trang
            var ProLst = new List<string>();
            var ProQry = from d in db.Products
                         orderby d.Manufacturer.manufacturerName
                         select d.Manufacturer.manufacturerName;
            ProLst.AddRange(ProQry.Distinct());
            ViewData["Manufacturer"] = new SelectList(ProLst);

            ViewBag.Heading = "Quản lý sản phẩm";
            return View(db.Products.ToList());
        }

        //Trang xem chi tiết sản phẩm
        public ActionResult Details(int id)
        {
            ViewBag.Heading = "Quản lý sản phẩm";
            if (id<0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //Trang tạo mới 1 sản phẩm
        public ActionResult Create()
        {
            ViewBag.Heading = "Quản lý sản phẩm";

            // Đổ dữ liệu vào combobox search theo thương hiệu khi load trang
            var ManuLst = new List<string>();
            var ManuQry = from d in db.Products
                          orderby d.Manufacturer.manufacturerName
                          select d.Manufacturer.manufacturerName;
            ManuLst.AddRange(ManuQry.Distinct());
            ViewData["Manufacturer"] = new SelectList(ManuLst);

            // Đổ dữ liệu vào combobox search theo CPU khi load trang
            var CPULst = new List<string>();
            var CPUQry = from d in db.Products
                         orderby d.CPU.cpuType
                         select d.CPU.cpuType;
            CPULst.AddRange(CPUQry.Distinct());
            ViewData["CPU"] = new SelectList(CPULst);

            // Đổ dữ liệu vào combobox search theo Screen khi load trang
            var ScreenLst = new List<string>();
            var ScreenQry = from d in db.Products
                            orderby d.Screen.size
                            select d.Screen.size;
            ScreenLst.AddRange(ScreenQry.Distinct());
            ViewData["Screen"] = new SelectList(ScreenLst);

            // Đổ dữ liệu vào combobox search theo Dung lượng đĩa khi load trang
            var HDLst = new List<string>();
            var HDQry = from d in db.Products
                        orderby d.HardDrive.diskSpace
                        select d.HardDrive.diskSpace;
            HDLst.AddRange(HDQry.Distinct());
            ViewData["HardDrive"] = new SelectList(HDLst);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productName,productType,shortDescription,longDescription,warrantyPeriod,cd_DVD,camera,wifi,os,battery,ram,unitPrice,isNoLonger,isNew,isHot,isSale,quantity,imageSrc,importPrice,ManufName,ScreenName,CPUName,HDrive")] Product product)
        {
            // Đổ dữ liệu vào combobox search theo thương hiệu khi load trang
            var ManuLst = new List<string>();
            var ManuQry = from d in db.Products
                          orderby d.Manufacturer.manufacturerName
                          select d.Manufacturer.manufacturerName;
            ManuLst.AddRange(ManuQry.Distinct());
            ViewData["Manufacturer"] = new SelectList(ManuLst);

            // Đổ dữ liệu vào combobox search theo CPU khi load trang
            var CPULst = new List<string>();
            var CPUQry = from d in db.Products
                         orderby d.CPU.cpuType
                         select d.CPU.cpuType;
            CPULst.AddRange(CPUQry.Distinct());
            ViewData["CPU"] = new SelectList(CPULst);

            // Đổ dữ liệu vào combobox search theo Screen khi load trang
            var ScreenLst = new List<string>();
            var ScreenQry = from d in db.Products
                            orderby d.Screen.size
                            select d.Screen.size;
            ScreenLst.AddRange(ScreenQry.Distinct());
            ViewData["Screen"] = new SelectList(ScreenLst);

            // Đổ dữ liệu vào combobox search theo Dung lượng đĩa khi load trang
            var HDLst = new List<string>();
            var HDQry = from d in db.Products
                        orderby d.HardDrive.diskSpace
                        select d.HardDrive.diskSpace;
            HDLst.AddRange(HDQry.Distinct());
            ViewData["HardDrive"] = new SelectList(HDLst);

            ViewBag.Heading = "Quản lý sản phẩm";
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // Trang cập nhật một sản phẩm
        public ActionResult Edit(int? id)
        {
           

            ViewBag.Heading = "Quản lý sản phẩm";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productID,productName,productType,shortDescription,longDescription,warrantyPeriod,cd_DVD,camera,wifi,os,battery,ram,unitPrice,isNoLonger,isNew,isHot,isSale,quantity,imageSrc,importPrice")] Product product)
        {
            

            ViewBag.Heading = "Quản lý sản phẩm";
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Trang xóa một sản phẩm
        public ActionResult Delete(int id)
        {
            ViewBag.Heading = "Quản lý sản phẩm";
            if (id<0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
