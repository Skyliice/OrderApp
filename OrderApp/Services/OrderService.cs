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
        var guidId = Guid.NewGuid().ToString();
        curOrder.Id = guidId;
        int? id;
        if ((await _orderRepository.GetAllOrders()).Count == 0)
            id = 1;
        else
            id = (await _orderRepository.GetAllOrders()).Last().UserId + 1;
        curOrder.UserId = id;
        await _orderRepository.AddOrder(curOrder);
    }
    
    public async Task<List<OrderClientDTO>> GetAllOrders()
    {
        var orders = await _orderRepository.GetAllOrders();
        var ordersClientDto = new List<OrderClientDTO>();
        foreach (var order in orders)
        {
            ordersClientDto.Add(order.MapToDto());
        }
        return ordersClientDto.OrderByDescending(o=>o.UserId).ToList();
    }

    public async Task DeleteOrder(string orderId)
    {
        await _orderRepository.DeleteOrder(orderId);
    }

    public async Task<OrderClientDTO> GetSingleOrder(string orderId)
    {
        var curOrder = await _orderRepository.GetSingleOrder(orderId);
        return curOrder.MapToDto();
    }
    
    public async Task<Order> GetSingleOrder(int orderUserId)
    {
        var curOrder = (await _orderRepository.GetAllOrders())
            .FirstOrDefault(o=>o.UserId==orderUserId);
        return curOrder;
    }
}