using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Laptop.Models
{
     [Bind(Exclude = "OrderId")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [DisplayName("Ngày đặt hàng")]
        public String OrderDate { get; set; }

        [DisplayName("Ngày giao dự kiến")]
        public String ShipDate { get; set; }

        [DisplayName("Ngày giao")]
        public String RealShipDate { get; set; }

        [DisplayName("Tài khoản")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Chưa nhập Họ")]
        [DisplayName("Họ")]
        [StringLength(100)]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Chưa nhập Tên")]
        [DisplayName("Tên")]
        [StringLength(100)]
        public string LastName { get; set; }

        [DisplayName("Tỉnh/Thành phố")]
        [StringLength(50)]
        public string Province { get; set; }

        [DisplayName("Huyện/Quận")]
        [StringLength(50)]
        public string District { get; set; }

        //[Required(ErrorMessage = "Chưa nhập địa chỉ")]
        [DisplayName("Địa chỉ")]
        [StringLength(200)]
        public string Address { get; set; }

        //[Required(ErrorMessage = "Chưa có thành phố")]
        //[DisplayName("Tỉnh/Thành phố")]
        //[StringLength(60)]
        public string City { get; set; }

        [StringLength(20)]
        public string PayForm { get; set; }


        //[Required(ErrorMessage = "Chưa xác định đã giao hay chưa")]
        [DisplayName("Đã thanh toán")]
        public bool IsPaid { get; set; }

        //[Required(ErrorMessage = "Chưa xác định có trả lại hay không")]
        [DisplayName("Trả lại")]
        public bool IsRemove { get; set; }

        //[Required(ErrorMessage = "Chưa nhập số điện thoại")]
        [StringLength(24)]
        public string Phone { get; set; }

        //[Required(ErrorMessage = "Chưa nhập email")]
        [DisplayName("Email")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        //    ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        //[Required(ErrorMessage = "Chưa nhập tổng giá trị hóa đơn")]
        [DisplayName("Tổng giá trị")]
        public decimal Total { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
