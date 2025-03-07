using App.Data.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SimoshStore;

namespace SimoshStoreAPI;

public class OrderService : IOrderService
{
    private readonly IDataRepository _Repository;
    private readonly IValidator<OrderDTO> _Validator;
    public OrderService(IValidator<OrderDTO> Validator, IDataRepository repository)
    {
        _Validator = Validator;
        _Repository = repository;
    }
    public async Task<IServiceResult> CreateOrderAsync(OrderDTO dto)
    {
        var validationResult = _Validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.Errors.First().ErrorMessage);
        }
        var order = MappingHelper.MappingOrderEntity(dto);
        await _Repository.AddAsync(order);
        return new ServiceResult(true, "Order created successfully");
    }
    public async Task<IServiceResult> UpdateOrderAsync(OrderDTO dto, int id)
    {
        var order = await _Repository.GetByIdAsync<OrderEntity>(id);
        if (order is null)
        {
            return new ServiceResult(false, "Order not found");
        }
        var validationResult = _Validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.Errors.First().ErrorMessage);
        }
        order.Address = dto.Address;
        order.UserId = dto.UserId;
        order.OrderCode = dto.OrderCode;
        await _Repository.UpdateAsync(order);
        return new ServiceResult(true, "Order updated successfully");
    }
    public async Task<OrderEntity> GetOrderByIdAsync(int id)
    {
        var order = await _Repository.GetAll<OrderEntity>()
                            .Include(o => o.User)
                            .Include(o => o.OrderItems)
                            .FirstOrDefaultAsync(o => o.Id == id);
        if (order is null)
        {
            throw new Exception("Order not found");
        }
        return order;
    }
    public async Task<IEnumerable<OrderEntity>> GetOrdersAsync()
    {
        var orders = await _Repository.GetAll<OrderEntity>()
                           .Include(o => o.User)
                           .Include(o => o.OrderItems)
                           .ToListAsync();
        if (orders == null)
        {
            throw new Exception("No orders found");
        }
        return orders;
    }
    public async Task<IServiceResult> DeleteOrderAsync(int id)
    {
        var order = await _Repository.GetByIdAsync<OrderEntity>(id);
        if (order is null)
        {
            return new ServiceResult(false, "Order not found");
        }
        await _Repository.DeleteAsync<OrderEntity>(id);
        return new ServiceResult(true, "Order deleted successfully");
    }
}
