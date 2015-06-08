using Laptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laptop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public int CartTotal { get; set; }

        public String Name { get; set; }
        public String ShipDate { get; set; }
        public String OrderDate { get; set; }
    }
}