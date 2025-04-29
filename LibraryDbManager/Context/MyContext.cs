using LibraryDbManager.DbModels;
using LibraryDbManager.DbModelsConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.Context
{
    public class MyContext:DbContext
    {

        public MyContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new AdminTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CostumerConfiguration());
            modelBuilder.ApplyConfiguration(new OderCofiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<AdminType> AdminTypes { get; set; }
        public DbSet<BookCategoryRelation> bookCategoryRelations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
