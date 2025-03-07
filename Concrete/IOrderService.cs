using App.Data.Entities;
using SimoshStore;

namespace SimoshStoreAPI;

public interface IOrderService
{
    Task<IEnumerable<OrderEntity>> GetOrdersAsync();
    Task<IServiceResult> DeleteOrderAsync(int id);
    Task<IServiceResult> UpdateOrderAsync(OrderDTO order, int id);
    Task<OrderEntity> GetOrderByIdAsync(int id);
}
