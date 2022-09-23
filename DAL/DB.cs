using BE;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DB : IdentityDbContext<User, Role, int>
    {
        public DB() : base()
        {
        }

        public DB(DbContextOptions<DB> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Pharmacy4;trusted_connection=true;MultipleActiveResultSets=true;");
                //("Server=.;Database=Pharmacy4;user ID=wikidaroo;password=M$8k6*kY0qHs0W;MultipleActiveResultSets=true;");

            base.OnConfiguring(optionsBuilder);

        }
        
        public DbSet<Drag> Drags { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_List> OrderLists { get; set; }
       // public DbSet<Order_Drag> OrderDrags { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Drag_Category> DragCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many Drag-Category
            modelBuilder.Entity<Drag_Category>()
                .HasKey(a => new {a.DragId, a.CategoryId});
            modelBuilder.Entity<Drag_Category>()
                .HasOne(dc => dc.Drag)
                .WithMany(dc => dc.DragCategories)
                .HasForeignKey((dc => dc.DragId));
            modelBuilder.Entity<Drag_Category>()
                .HasOne(dc => dc.Catagory)
                .WithMany(dc => dc.DragCategories)
                .HasForeignKey(dc => dc.CategoryId);
            base.OnModelCreating(modelBuilder);
            //one to many user-order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(u => u.UserId);
            //one to many brand-Drag
            modelBuilder.Entity<Drag>()
                .HasOne(d => d.Brand)
                .WithMany(b => b.Drags)
                .HasForeignKey(d => d.BrandId);
        }
    }
}