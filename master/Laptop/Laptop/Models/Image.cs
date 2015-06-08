using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laptop.Models
{
    public class Image
    {
        public String imageID { get; set; }


        public String imageName { get; set; }


        public String src { get; set; }

        public virtual Product product { get; set; }
    }
}
