using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laptop.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        [Required(ErrorMessage = "Chưa nhập tài khoản.")]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Chưa nhập tên.")]
        [StringLength(30, ErrorMessage = "Tên không được ít hơn 1 ký tự.", MinimumLength = 1)]
        [Display(Name = "Tên")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Chưa nhập họ.")]
        [StringLength(50, ErrorMessage = "Họ không được ít hơn 3 ký tự.", MinimumLength = 3)]
        [Display(Name = "Họ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Chưa nhập địa chỉ.")]
        [StringLength(50, ErrorMessage = "Địa chỉ không được ít hơn 10 ký tự.", MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Chưa nhập số email.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Địa chỉ email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Chưa nhập số điện thoại.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Số điện thoại không hợp lệ.")]
        [Display(Name = "Điên thoại")]
        public string Phone { get; set; }

         [Display(Name = "Tỉnh")]
        public string Town { get; set; }
    }
}