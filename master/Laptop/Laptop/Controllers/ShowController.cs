using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace Laptop.Models
{
    public class ShowController : Controller
    {
        private LaptopEntities db = new LaptopEntities();

        // GET: /Show/       
        public ActionResult ShowNew()
        {
            var newproducts = db.Products.Where(g => g.isNew == true);
            return PartialView(newproducts);
        }
        public ActionResult ShowHot()
        {
            var hotproducts = db.Products.Where(g => g.isHot == true);
            return PartialView(hotproducts);
        }

        public ActionResult ShowSlide()
        {
            var threeFirst = db.Products.Where(g => g.isHot == true);
            return PartialView(threeFirst);
        }
        public ActionResult ShowNewProduct(int? page)
        {
            // Đổ dữ liệu vào combobox search theo giá khi load trang
            List<SelectListItem> CostLst = new List<SelectListItem>();
            CostLst.Add(new SelectListItem { Text = "Trên 12 triệu", Value = "1" });
            CostLst.Add(new SelectListItem { Text = "Dưới 12 triệu", Value = "2" });
            ViewData["cost"] = CostLst;

            // Đổ dữ liệu vào combobox search theo thương hiệu khi load trang
            var ManuLst = new List<string>();
            var ManuQry = from d in db.Products
                          orderby d.Manufacturer.manufacturerName
                          select d.Manufacturer.manufacturerName;
            //var ManuQry = db.Products.Select(t => t.ManufName);
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

            // Đổ dữ liệu vào combobox search theo RAM khi load trang
            var RAMLst = new List<string>();
            var RAMQry = from d in db.Products
                            orderby d.ram
                            select d.ram;
            RAMLst.AddRange(RAMQry.Distinct());
            ViewData["RAM"] = new SelectList(RAMLst);

            // Đổ dữ liệu vào combobox search theo Card đồ họa khi load trang
            List<SelectListItem> GraphicLst = new List<SelectListItem>();
            GraphicLst.Add(new SelectListItem { Text = "Có", Value = "1" });
            GraphicLst.Add(new SelectListItem { Text = "Không", Value = "2" });
            ViewData["Graphic"] = GraphicLst;

            // Đổ dữ liệu vào combobox search theo Dung lượng đĩa khi load trang
            var HDLst = new List<string>();
            var HDQry = from d in db.Products
                         orderby d.HardDrive.diskSpace
                        select d.HardDrive.diskSpace;
            HDLst.AddRange(HDQry.Distinct());
            ViewData["HardDrive"] = new SelectList(HDLst);

            // Lấy sản phẩm mới
            var pro = db.Products.Where(p => p.isNew == true).OrderBy(p=>p.productID);
            //return View(pro.ToList()); // Trả về trang sản phẩm mới

            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(pro.ToPagedList(pageNumber, pageSize));

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
