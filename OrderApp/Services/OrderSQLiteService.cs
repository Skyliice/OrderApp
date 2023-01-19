using Microsoft.EntityFrameworkCore;
using OrderApp.Models;

namespace OrderApp.Services;

public class OrderSQLiteService
{
    private OrderDb _context;
    
    public OrderSQLiteService(OrderDb context)
    {
        _context = context;
        context.Database.EnsureCreated();
    }

    public async Task<List<Order>> GetAllOrders()
    {
        var itemList = new List<Order>();
        itemList = await _context.Orders.ToListAsync();
        return itemList;
    }

    public async Task<Order> GetSingleOrder(string id)
    {
        var curOrder = await _context.Orders.FindAsync(id);
        return curOrder;
    }

    public async Task AddOrder(Order orderToAdd)
    {
        await _context.Orders.AddAsync(orderToAdd);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrder(string id)
    {
        var curOrder = await _context.Orders.FindAsync(id);
        _context.Orders.Remove(curOrder);
        await _context.SaveChangesAsync();
    }
}