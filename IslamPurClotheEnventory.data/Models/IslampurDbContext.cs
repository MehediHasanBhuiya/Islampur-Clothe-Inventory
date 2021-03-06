﻿using IslampurClotheEnventory.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace IslampurClotheEnventory.Data
{
    public class IslampurDbContext : IdentityDbContext<ApplicationUser>
    {
        public IslampurDbContext(DbContextOptions<IslampurDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchesInfo> PurchesInfos { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
