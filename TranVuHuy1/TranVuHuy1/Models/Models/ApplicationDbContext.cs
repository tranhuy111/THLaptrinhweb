﻿using Microsoft.EntityFrameworkCore;

namespace TranVuHuy.Models
{
    public class ApplicationDbContext:DbContext
    {
        public
ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}
