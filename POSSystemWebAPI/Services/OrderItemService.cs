using POSSystemWebAPI.Interfaces;
using POSSystemWebAPI.Models;
using POSSystemWebAPI.Models.DTOs;

namespace POSSystemWebAPI.Services
{

    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repo;
        public OrderItemService(IOrderItemRepository repo) => _repo = repo;

        public async Task<List<OrderItemViewDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(e => new OrderItemViewDto
            {
                ItemId = e.ItemId,
                ItemName = e.ItemCategory?.Item,
                LocationName = e.Location?.LocationName,
                StandardCost = e.StandardCost,
                StandardPrice = e.StandardPrice,
                Margin = e.Margin,
                Quantity = e.Quantity,
                FreeQuantity = e.FreeQuantity,
                Discount = e.Discount,
                TotalCost = e.TotalCost,
                TotalSelling = e.TotalSelling
            }).ToList();
        }

        public Task SaveAsync(IEnumerable<OrderItemDto> dtos, string userName)
        {
            var entities = dtos.Select(d => new OrderItem
            {
                ItemId = d.ItemId,
                ItemCategoryId = d.ItemCategoryId,
                LocationId = d.LocationId,
                StandardCost = d.StandardCost,
                StandardPrice = d.StandardPrice,
                Margin = d.Margin,
                Quantity = d.Quantity,
                FreeQuantity = d.FreeQuantity,
                Discount = d.Discount,
                TotalCost = d.TotalCost,
                TotalSelling = d.TotalSelling
            });
            return _repo.UpsertRangeAsync(entities, userName);
        }
    }
}