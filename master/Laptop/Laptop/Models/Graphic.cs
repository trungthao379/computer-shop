using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Laptop.Models
{
    public class Graphic
    {
        [Key]
        public int graphicID { get; set; }

        [DisplayName("Tên")]
        public String graphicName { get; set; }

        [DisplayName("Nhà sản xuất")]
        public String manufacturer { get; set; }

        [DisplayName("Loại")]
        public String graphicType { get; set; }

        [DisplayName("Hết hàng")]
        public bool isNoLonger { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
