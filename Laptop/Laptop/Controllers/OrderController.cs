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
using Laptop.ViewModels;

namespace Laptop.Models
{
    
    public class OrderController : Controller
    {

        public const string CartSessionKey = "CartId";
        private LaptopEntities db = new LaptopEntities();
        public Order orderModel;
        public static string name;
        public static string Odate;
        public static string Sdate;
        public static Cart c;

        // Trang nhập thông tin đặt hàng

        [Authorize] // Bắt buộc đăng nhập mới có thể đặt hàng
        public ActionResult Index()
        {
            HttpContextBase http = this.HttpContext;
            string uName = http.User.Identity.Name;
            var x = db.Users.SingleOrDefault(t => t.UserName.Equals(uName));

            //Đổ dữ liệu lên combobox
            var TownLst = new List<string>();
            var TownQry = from d in db.Provinces
                          orderby d.provinceName
                          select d.provinceName;
            TownLst.AddRange(TownQry.Distinct());
            ViewData["Town"] = new SelectList(TownLst);

            var DLst = new List<string>();
            var DQry = from d in db.Districts
                       where d.Province.provinceName.Equals("Bà Rịa-Vũng Tàu")
                       orderby d.districtName
                       select d.districtName;
            DLst.AddRange(DQry.Distinct());
            ViewData["District"] = new SelectList(DLst);

            List<SelectListItem> PayForm = new List<SelectListItem>();
            PayForm.Add(new SelectListItem { Text = "Thanh toán tại nhà", Value = "Tại nhà" });
            PayForm.Add(new SelectListItem { Text = "Thanh toán Online", Value = "Online" });
            PayForm.Add(new SelectListItem { Text = "Thanh toán bằng thẻ Ngân hàng", Value = "Thẻ tín dụng" });
            ViewData["PayForm"] = PayForm;
            return View(x);
        }
        [HttpPost]
        public ActionResult FillDataToCbb(string id)
        {
            var x = db.Districts.Where(p => p.Province.provinceName.Equals(id));
            return Json(x);
        }

        [HttpPost]
        public ActionResult abc(string id)
        {
            var x = db.Districts.Where(p => p.Province.provinceName.Equals(id));
            return Json(x);
        }
        public ActionResult OrderHandle(String fname, String lname, String address, String phone, String email,
            String town, String District, String PayForm)
        {
            // Kiểm tra nếu còn hàng thì order thành công 
            // Nếu không còn hàng thì order thất bại
            //Nhưng project này mặc định luôn có hàng

            // Lưu thông tin Order và OrderDetail
            var order = new Order();
            var cart = ShoppingCart.GetCart(this.HttpContext);
            HttpContextBase http = this.HttpContext;

            // Lưu lại thông tin đặt hàng
            String d = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            order.OrderDate = d;
            order.Username = http.User.Identity.Name;
            order.FirstName = fname;
            order.LastName = lname;
            order.Address = address;
            order.Phone = phone;
            order.Email = email;
            order.IsPaid = false;
            order.IsRemove = false;
            order.City = town;
            order.District = District;
            order.PayForm = PayForm;
            order.Total = cart.GetTotal();
            order.ShipDate = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");

            db.Orders.Add(order);

            name = lname + " " + fname;
            Odate = d;
            Sdate = order.ShipDate;
            orderModel = order;
            //Lưu chi tiết đặt hàng
            string cartID = cart.GetCartId(this.HttpContext);
            var listItem = db.Carts.Where(p => p.CartId.Equals(cartID)); // Lấy những sản phẩm trong giỏ hàng có cartID
            bool leak = false;
            foreach (var x in listItem)
            {
                OrderDetail od = new OrderDetail();
                od.Quantity = x.Count;
                if (od.Quantity >= x.Product.quantity) // Kiểm tra nếu số lượng của sản phẩm có đủ hay không
                {
                    leak = true; // Nếu thiếu thì bật cờ leak lên
                    c = x;
                    break;
                }
                od.Order = order;
                od.Product = x.Product;

                db.OrderDetails.Add(od);
            }
            if (leak)
            {
                return RedirectToAction("OrderFail");// Chuyển sang trang thông báo đặt hàng KHÔNG thành công
            }


            foreach (var x in listItem) // Nếu lưu thành công tất cả Order detail thì cập nhật số lượng lại trước khi chuyển trang
            {
                UpdateQuantityOfProduct(x.Product.productID, x.Count);
            }

            // Chuẩn bị mail
            string mailTo = "phuongch93@gmail.com";
            string subject = "Hoàng Phương Computer - Đặt hàng";
            string body = "Cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi!<br>"
                + "Tài khoản: " + order.Username + "<br>" + "Người nhận: " + order.LastName + " " + order.FirstName
                + "<br>Ngày nhận: trong vòng 7 ngày kể từ ngày đặt hàng (" + order.OrderDate + ")<br>Đây là hóa đơn của khách hàng<hr>"
                + "<table><tr><th>Sản phẩm</th><th>Số lượng</th><th>Đơn giá</th></tr>";
            string con = "";
            foreach (var x in listItem)
            {
                con += "<tr><td>" + x.Product.productName + "</td><td>" + x.Count + "</td><td>" + x.Product.unitPrice + "</td></tr>";
            }
            body = body + con + "</table><hr>Tổng số tiền: " + order.Total +
                "<br> Chúng tôi sẽ liên lạc qua số điện thoại được cung cấp khi giao hàng! Cảm ơn quý khách.";

            XMail.Send(mailTo, subject, body);

            db.SaveChanges();

            return RedirectToAction("OrderSuccess");// Chuyển sang trang thông báo đặt hàng thành công

        }

        public ActionResult OrderSuccess()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            //Đưa dữ liệu về view hiển thị ra những  item trong giỏ hàng mà khách hàng đã đặt để confirm lại
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal(),
                Name = name,
                OrderDate = Odate,
                ShipDate = Sdate
            };
          
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult FillUserInformation(string userName)
        {
            string username = Session["user"].ToString();
            var u = db.Users.Find(username);
            return Json(u);
        }
        public ActionResult OrderFail()
        {
            return View(c);
        }
        public void UpdateQuantityOfProduct(int id, int num)
        {
            var pro = db.Products.Find(id);
            pro.quantity = pro.quantity - num;
        }
    }
}
