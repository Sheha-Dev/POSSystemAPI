using Microsoft.EntityFrameworkCore;
using POS_System_Web_API.Models.Entities;

namespace POSSystemWebAPI.Models
{

    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options) : base(options) { }

        public DbSet<LocationDetail> Locations => Set<LocationDetail>();
        public DbSet<ItemCategory> ItemCategories => Set<ItemCategory>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the 7 fruits so the bill has ItemCategoryIds to reference
            modelBuilder.Entity<ItemCategory>().HasData(
                new ItemCategory { ItemCategoryId = 1, Item = "Mango", IsActive = true },
                new ItemCategory { ItemCategoryId = 2, Item = "Apple", IsActive = true },
                new ItemCategory { ItemCategoryId = 3, Item = "Banana", IsActive = true },
                new ItemCategory { ItemCategoryId = 4, Item = "Orange", IsActive = true },
                new ItemCategory { ItemCategoryId = 5, Item = "Grapes", IsActive = true },
                new ItemCategory { ItemCategoryId = 6, Item = "Kiwi", IsActive = true },
                new ItemCategory { ItemCategoryId = 7, Item = "Strawberry", IsActive = true }
            );
        }
    }
}