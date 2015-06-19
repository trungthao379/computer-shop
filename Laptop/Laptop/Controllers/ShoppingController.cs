using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laptop;
using Laptop.Models;
using Laptop.ViewModels;

namespace Laptop.Models
{
    public class ShoppingController : Controller
    {
        private LaptopEntities db = new LaptopEntities();

        // Trang Shopping cart
        // Hiển thị giỏ hàng
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Chuẩn bị ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            // Trả về view
            return View(viewModel);
        }

        // Xử lý sự kiện thêm một sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int id)
        {
            // Lấy ra sản phẩm cần thêm
            var addedProduct = db.Products
                .Single(pr => pr.productID == id);

            // Thêm sản phẩm đó vào giỏ hàng shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedProduct); // Việc thêm giao cho đối tượng thuộc lớp ShoppingCart thực hiện

            // Trở về giỏ hàng sau  khi thêm
            return RedirectToAction("Index","Shopping");
        }

        //Xử lý việc người dùng nhập số lượng cần mua
        [HttpPost]
        public ActionResult AddToCart(int id, int num)
        {

            // Lấy ra sản phẩm có ProductID = id
            var addedProduct = db.Products
                .Single(pr => pr.productID == id);
            //Lấy giỏ hàng
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Nếu giỏ nhập số lượng là 0
            if (num == 0)
            {
                cart.RemoveFromCart(id);
            }
            else
            {
                // Thêm nó vào giỏ hàng với số lượng tương ứng           
                cart.AddToCart(addedProduct, num);
            }            

            // Trở về trang giỏ hàng của khách
            // Gửi thông tin về view 
            var results = new ShoppingCartRemoveViewModel
            {
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = num,
                DeleteId = id
            };
            return Json(results); // Gửi bằng Json
        }

        // Xử lý sự kiện khi người dùng nhấn link Remove from cart để xóa 1 sản phẩm tương ứng
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Lấy giỏ hàng của người đăng nhập
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Lấy tên sản phẩm để hiển thị thông báo sau khi xóa thành công
            string product = db.Carts
                .Single(item => item.RecordId == id).Product.productName;

            // Xóa khỏi giỏ hàng
            int itemCount = cart.RemoveFromCart(id);

            // Gửi thông tin về view 
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(product) +
                    " đã được trả lại thành công!",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results); // Gửi bằng Json
        }

        //Xử lý sự kiện nhấn nút Empty Cart
        public ActionResult EmptyCart()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.EmptyCart(); //  Việc làm rỗng giỏ hàng được giao cho đối tượng thuộc lớp ShoppingCart
            return RedirectToAction("Index");
        }

        // Hiển thị có bao nhiêu sản phẩm được thêm vào giỏ
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }

        //---------------------------------------------------------------------------------------------------------------------
        
    }
}
