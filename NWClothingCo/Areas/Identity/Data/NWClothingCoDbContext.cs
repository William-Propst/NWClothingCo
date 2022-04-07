using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NWClothingCo.Areas.Identity.Data;
using NWClothingCo.Models;

namespace NWClothingCo.Data
{
    public class NWClothingCoDbContext : IdentityDbContext<NWClothingCoUser>
    {
        public NWClothingCoDbContext(DbContextOptions<NWClothingCoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Order_Details> Order_Details { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetails> Cart_Details { get; set; }
    }
}
