using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laptop.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Chưa nhập tài khoản")]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        [StringLength(100, ErrorMessage = "Mật khẩu ít nhất là 6 ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Chưa nhập tên")]
        [Display(Name = "Tên")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Chưa nhập họ")]
        [Display(Name = "Họ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Chưa nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Chưa nhập email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Chưa nhập số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Điên thoại")]
        public string Phone { get; set; }

        [Display(Name = "Tỉnh/Thành phố")]
        public string Town { get; set; }

        [Display(Name = "Huyện/Quận")]
        public string District { get; set; }

        [Display(Name = "CMND")]
        public string IdentityCard { get; set; }

        [Display(Name = "Vai trò")]
        public string Role { get; set; }

        [Display(Name="Đã kích hoạt")]
        public bool Active {get;set;}
    }
}