using Laptop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Laptop
{
    public class LaptopEntities:DbContext
    {
        public LaptopEntities() : base("LaptopEntities") { }
        public LaptopEntities(string connectionStringOrName)
            : base(connectionStringOrName) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Screen> Screens { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<Graphic> Graphics { get; set; }
        public DbSet<HardDrive> HardDrives { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
    }
}