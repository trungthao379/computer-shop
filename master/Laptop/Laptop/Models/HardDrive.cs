using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Laptop.Models
{
    public class HardDrive
    {
        [Key]
        public int hardDriveID { get; set; }

        [DisplayName("Tên")]
        public String hardDriveName { get; set; }

         [DisplayName("Nhà sản xuất")]
        public String manufacturer { get; set; }

        [DisplayName("Dung lượng")]
        public string diskSpace { get; set; }

         [DisplayName("Loại")]
        public int hardDriveType { get; set; }

        [DisplayName("Hết hàng")]
        public bool isNoLonger { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
