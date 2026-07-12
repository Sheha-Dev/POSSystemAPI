using POSSystemWebAPI.Models;

namespace POSSystemWebAPI.Interfaces
{

    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllAsync();
        Task UpsertRangeAsync(IEnumerable<OrderItem> items, string userName);
    }

}