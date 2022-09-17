﻿using WorldTelecomFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace WorldTelecomFinal.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }

        public DbSet<Tag> Tags  { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductsTag { get; set; }
        public DbSet<ProductImage> ProductsImage { get; set; }





    }
}