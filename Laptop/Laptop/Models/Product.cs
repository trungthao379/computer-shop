using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laptop.Models
{
    
    public class Product
    {
        [Key]
        public int productID { get; set; }

        [Required(ErrorMessage="Thiếu tên sản phẩm")]
        [DisplayName("Tên sản phẩm")]
        public String productName { get; set; }

        [DisplayName("Loại sản phẩm")]
        public String productType { get; set; }

        [DisplayName("Mô tả sơ lược")]
        public String shortDescription { get; set; }

        [DisplayName("Mô tả")]
        public String longDescription { get; set; }

        [Required(ErrorMessage = "Thiếu thời gian bảo hành")]
        [DisplayName("Bảo hành")]
        public String warrantyPeriod { get; set; }

        [DisplayName("Đọc đĩa")]
        public String cd_DVD { get; set; }

        [DisplayName("Camera")]
        public String camera { get; set; }

        [DisplayName("wifi")]
        public String wifi { get; set; }

        [DisplayName("Hệ điều hành")]
        public String os { get; set; }

        [DisplayName("Pin")]
        public String battery { get; set; }

        [DisplayName("RAM")]
        public String ram { get; set; }

        [DisplayName("Đơn giá")]

        [Required(ErrorMessage = "Thiếu giá sản phẩm")]
        public int unitPrice { get; set; }

        [DisplayName("Hết hàng")]
        public bool isNoLonger { get; set; }

        [DisplayName("Hàng mới")]
        public bool isNew { get; set; }

        [DisplayName("Bán chạy")]
        public bool isHot { get; set; }

        [DisplayName("Giảm giá")]
        public bool isSale { get; set; }

        [Required(ErrorMessage = "Thiếu số lượng sản phẩm")]
        [DisplayName("Số lượng")]
        public int quantity { get; set; }

        [DisplayName("Ảnh")]
        public string imageSrc { get; set; }

        [Required(ErrorMessage = "Thiếu giá nhập sản phẩm")]
        [DisplayName("Giá nhập")]
        public decimal importPrice { get; set; }

        [DisplayName("Nhà sản xuất")]
        public string ManufName { get; set; }

        [DisplayName("Màn hình")]
        public string ScreenName { get; set; }

        [DisplayName("CPU")]
        public string CPUName { get; set; }

        [DisplayName("HardDrive")]
        public string HDrive { get; set; }

        public virtual Screen Screen { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual CPU CPU { get; set; }
        public virtual Graphic Graphic { get; set; }
        public virtual HardDrive HardDrive { get; set; }
        public virtual List<Image> images { get; set; }
    }
}