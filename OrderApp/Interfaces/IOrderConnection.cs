using OrderApp.Models;

namespace OrderApp.Interfaces;

public interface IOrderConnection
{
    public Task<List<Order>> GetAllOrders();
    public Task<Order> GetSingleOrder(string id);
    public Task AddOrder(Order orderToAdd);
    public Task DeleteOrder(string id);
}