using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Sales Database;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasDefaultValue("No description");
            modelBuilder.Entity<Sale>()
                .Property(s => s.Date).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { CustomerId = 1, Name = "John Doe", Email = "", CreaditCardNumber = "1234-5678-9012-3456" }
                );
           modelBuilder.Entity<Store>()
                .HasData(
                new Store { StoreId = 1, Name = "Main Street Store" },
                new Store { StoreId = 2, Name = "Downtown Store" }
                );
            modelBuilder.Entity<Product>()
                .HasData(
                new Product { ProductId = 1, Name = "Laptop", Quantity = 10, Price = 999.99m, Description = "High-performance laptop" },
                new Product { ProductId = 2, Name = "Smartphone", Quantity = 50, Price = 499.99m, Description = "Latest model smartphone" }
                );
            modelBuilder.Entity<Sale>()
                .HasData(
                new Sale { SaleId = 1, Date = new DateTime(2023, 1, 1), CustomerId = 1, StoreId = 1, ProductId = 1 },
                new Sale { SaleId = 2, Date = new DateTime(2023, 1, 1), CustomerId = 1, StoreId = 2, ProductId = 2 }
                );
        }
    }
}
