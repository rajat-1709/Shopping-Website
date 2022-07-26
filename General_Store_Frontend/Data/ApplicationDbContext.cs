using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using sampleshopping1frontend.Models;

namespace sampleshopping1frontend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<sampleshopping1frontend.Models.ShoppingCart> ShoppingCart { get; set; }
        public DbSet<sampleshopping1frontend.Models.UserLogin> UserLogin { get; set; }
        public DbSet<sampleshopping1frontend.Models.UserRegistration> UserRegistration { get; set; }
        public DbSet<sampleshopping1frontend.Models.Orderdetails> Orderdetails { get; set; }
        public DbSet<sampleshopping1frontend.Models.Admin> Admin { get; set; }
        public DbSet<sampleshopping1frontend.Models.Products> Products { get; set; }
    }
}
