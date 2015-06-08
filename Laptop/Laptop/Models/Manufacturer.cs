using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Laptop.Models
{
    public class Manufacturer
    {
        [Key]
        public int manufacturerID { get; set; }

        [DisplayName("Nhà sản xuất")]
        public String manufacturerName { get; set; }
    }
}
