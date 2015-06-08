using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laptop.Models
{
    public class Province
    {
        [Key]
        public int provinceID { get; set; }
        public String provinceName { get; set; }
        public virtual List<District> Districts { get; set; }

    }
}