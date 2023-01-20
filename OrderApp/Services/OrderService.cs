using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

    public async Task<Order> AddOrder(Order curOrder)
    {
        if (_orderRepository.CanConnect())
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
            return curOrder;
        }
        else
        {
            return curOrder;
        }
    }
    
    public async Task<List<OrderClientDTO>> GetAllOrders()
    {
        if (_orderRepository.CanConnect())
        {
            var orders = await _orderRepository.GetAllOrders();
            var ordersClientDto = new List<OrderClientDTO>();
            foreach (var order in orders)
            {
                ordersClientDto.Add(order.MapToDto());
            }

            return ordersClientDto.OrderByDescending(o => o.UserId).ToList();
        }
        else
        {
            return new List<OrderClientDTO>();
        }
    }

    public async Task DeleteOrder(string orderId)
    {
        if (_orderRepository.CanConnect())
        {
            await _orderRepository.DeleteOrder(orderId);
        }
    }

    public async Task<Order> GetSingleOrder(int orderUserId)
    {
        if (_orderRepository.CanConnect())
        {
            var curOrder = (await _orderRepository.GetAllOrders())
                .FirstOrDefault(o => o.UserId == orderUserId);
            return curOrder;
        }
        else
        {
            return null;
        }
    }
}