using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Laptop.Models
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        LaptopEntities db = new LaptopEntities();
        public ActionResult Index(string Manufacturer, string searchString, string Cost,
            string CPU, string Graphic, string RAM, string Screen, string HardDrive)
        {
            // Đổ dữ liệu vào combobox search theo thương hiệu khi load trang
            //var ProLst = new List<string>();
            //var ProQry = from d in db.Products
            //              orderby d.Manufacturer.manufacturerName
            //              select d.Manufacturer.manufacturerName;
            //ProLst.AddRange(ProQry.Distinct());
            //ViewData["Manufacturer"] = new SelectList(ProLst);

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
            ManuLst.AddRange(ManuQry.Distinct());
            ViewData["Manufacturer"] = new SelectList(ManuLst);

            // Đổ dữ liệu vào combobox search theo CPU khi load trang
            var CPULst = new List<string>();
            var CPUQry = from d in db.Products
                         orderby d.CPU.cpuType
                         select d.CPU.cpuType;
            ManuLst.AddRange(CPUQry.Distinct());
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

            // Lấy tiêu chí search từ view gửi lên để search
            var kq = from s in db.Products
                     select s;
            ViewBag.flag = false;

            if (!string.IsNullOrEmpty(searchString)) // Tìm theo tên
            {
                kq = kq.Where(s => s.productName.Contains(searchString));
                ViewBag.flag = true;
            }
            if (!string.IsNullOrEmpty(Manufacturer)) // Tìm theo thương hiệu
            {
                kq = kq.Where(x => x.Manufacturer.manufacturerName.Equals(Manufacturer));
                ViewBag.flag = true;
            }
            if (Cost == "1") // Tìm theo giá
            {
                kq = kq.Where(x => x.unitPrice >= 12000000);
                ViewBag.flag = true;
            }
            if (Cost == "2") 
            {
                kq = kq.Where(x => x.unitPrice <= 12000000);
                ViewBag.flag = true;
            }
            if(!string.IsNullOrEmpty(CPU)) // Tìm theo loại CPU
            {
                kq = kq.Where(x => x.CPU.cpuType.Equals(CPU));
                ViewBag.flag = true;
            }
            if (Graphic == "1") // Tìm theo loại Graphic
            {
                kq = kq.Where(x => x.Graphic != null);
                ViewBag.flag = true;
            }
            if (Graphic == "2") 
            {
                kq = kq.Where(x => x.Graphic == null);
                ViewBag.flag = true;
            }
            if (!string.IsNullOrEmpty(HardDrive)) // Tìm theo HardDrive
            {
                kq = kq.Where(x => x.HardDrive.diskSpace.Equals(HardDrive));
                ViewBag.flag = true;
            }

            if (!string.IsNullOrEmpty(RAM)) // Tìm theo RAM
            {
                kq = kq.Where(x => x.ram.Equals(RAM));
                ViewBag.flag = true;
            }

            if (!string.IsNullOrEmpty(Screen)) // Tìm theo Screen
            {
                kq = kq.Where(x => x.Screen.size.Equals(Screen));
                ViewBag.flag = true;
            }

            // Xét theo cờ flag
            if(ViewBag.flag == false)
            {
                return RedirectToAction("ShowNewProduct","Show");
            }

            int pageSize = 9;
            int pageNumber = 1;
            kq = kq.OrderBy(p => p.productID);
            return View(kq.ToPagedList(pageNumber,pageSize));
        }
	}
}