using OrderApp.Interfaces;
using OrderApp.Models;

namespace OrderApp.Services;

public class OrderService
{
    private IOrderConnection _orderRepository;

    public OrderService(IOrderConnection orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task AddOrder(Order curOrder)
    {
        var id = Guid.NewGuid().ToString();
        curOrder.Id = id;
        await _orderRepository.AddOrder(curOrder);
    }
    
    public async Task<List<Order>> GetAllOrders()
    {
        return await _orderRepository.GetAllOrders();
    }

    public async Task DeleteOrder(string orderId)
    {
        await _orderRepository.DeleteOrder(orderId);
    }

    public async Task<Order> GetSingleOrder(string orderId)
    {
        return await _orderRepository.GetSingleOrder(orderId);
    }
}