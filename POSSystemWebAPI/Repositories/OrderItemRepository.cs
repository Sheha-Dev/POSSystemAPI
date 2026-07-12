using Microsoft.EntityFrameworkCore;
using POSSystemWebAPI.Interfaces;
using POSSystemWebAPI.Models;

namespace POSSystemWebAPI.Repositories
{

    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly POSDbContext _db;
        public OrderItemRepository(POSDbContext db) => _db = db;

        public async Task<List<OrderItem>> GetAllAsync() =>
            await _db.OrderItems.AsNoTracking()
                .Include(x => x.ItemCategory)
                .Include(x => x.Location)
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.ItemId)
                .ToListAsync();

        public async Task UpsertRangeAsync(IEnumerable<OrderItem> items, string userName)
        {
            var now = DateTime.UtcNow;

            foreach (var item in items)
            {
                if (item.ItemId > 0)
                {
                    var found = await _db.OrderItems.FindAsync(item.ItemId);
                    if (found is null) continue;

                    found.ItemCategoryId = item.ItemCategoryId;
                    found.LocationId = item.LocationId;
                    found.StandardCost = item.StandardCost;
                    found.StandardPrice = item.StandardPrice;
                    found.Margin = item.Margin;
                    found.Quantity = item.Quantity;
                    found.FreeQuantity = item.FreeQuantity;
                    found.Discount = item.Discount;
                    found.TotalCost = item.TotalCost;
                    found.TotalSelling = item.TotalSelling;
                    found.UpdatedBy = userName;
                    found.UpdatedDate = now;
                }
                else
                {
                    item.CreatedBy = userName;
                    item.CreatedDate = now;
                    item.IsActive = true;
                    _db.OrderItems.Add(item);
                }
            }

            await _db.SaveChangesAsync();
        }
    }
}