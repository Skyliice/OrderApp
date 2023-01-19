using Microsoft.EntityFrameworkCore;

namespace OrderApp.Models;

public class OrderDb : DbContext
{
    public OrderDb(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Order> Orders { get; set; } = null!;
}