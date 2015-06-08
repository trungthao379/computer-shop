using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laptop.Models
{
    public class District
    {
        [Key]
        public virtual int districtID { get; set; }
        public virtual String districtName { get; set; }
        public virtual Province Province {get;set;}
    }
}