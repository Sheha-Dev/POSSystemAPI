using POSSystemWebAPI.Models.DTOs;

namespace POSSystemWebAPI.Interfaces
{

    public interface IOrderItemService
    {
        Task<List<OrderItemViewDto>> GetAllAsync();
        Task SaveAsync(IEnumerable<OrderItemDto> items, string userName);
    }
}