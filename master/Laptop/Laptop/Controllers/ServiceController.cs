using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laptop.Models
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/
        //Trang chủ
        public ActionResult Index()
        {
            return RedirectToAction("ShowNewProduct", "Show");
        }
        //Trang Giới thiệu
        public ActionResult About()
        {
            return View();
        }
        //Trang Hỗ trợ khách hàng
        public ActionResult Contact()
        {
            return View();
        }
	}
}