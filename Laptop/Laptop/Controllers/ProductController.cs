using Laptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Laptop.Controllers
{
    public class ProductController : Controller
    {
        private LaptopEntities db = new LaptopEntities();

        public ActionResult ByManufacturer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Manufacturer m = db.Manufacturers.FirstOrDefault(t => t.manufacturerID == id);
            if (m == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = string.Format("Sản phẩm của {0}", m.manufacturerName);
            List<Product> products = db.Products.Where(t => t.Manufacturer.manufacturerID.Equals(m.manufacturerID)).ToList();
            return View(products);
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