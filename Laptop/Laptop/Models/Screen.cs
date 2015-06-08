using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Laptop.Models
{
    public class Screen
    {
        [Key]
        public int screenID { get; set; }

        [DisplayName("Tên màn hình")]
        public String screenName { get; set; }

        [DisplayName("Nhà sản xuất")]
        public String manufacturer { get; set; }

        [DisplayName("Kích thước")]
        public string size { get; set; }

        [DisplayName("Cảm ứng")]
        public bool touchScreen { get; set; }

        [DisplayName("Độ phân giải")]
        public String resolution { get; set; }

        [DisplayName("Hết hàng")]
        public bool isNoLonger { get; set; }

        [DisplayName("Loại")]
        public String type { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
