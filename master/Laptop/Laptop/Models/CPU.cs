using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Laptop.Models
{
    public class CPU
    {
        [Key]
        public int cpuID { get; set; }

        [DisplayName("Tên CPU")]
        public String cpuName { get; set; }

        [DisplayName("Nhà sản xuất")]
        public String manufacturer { get; set; }

        [DisplayName("Công nghệ")]
        public String technology { get; set; }

        [DisplayName("Loại CPU")]
        public String cpuType { get; set; }

        [DisplayName("Tốc độ")]
        public String speed { get; set; }

        [DisplayName("Hết hàng")]

        public bool isNoLonger { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
