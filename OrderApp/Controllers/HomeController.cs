using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrderApp.Models;
using OrderApp.Services;

namespace OrderApp.Controllers;

public class HomeController : Controller
{
    private OrderSQLiteService _orderSqLiteService;
    private List<Order> _ordersList;

    public HomeController(OrderSQLiteService orderSqLiteService)
    {
        _orderSqLiteService = orderSqLiteService;
    }

    public async Task<IActionResult> Index()
    {
        _ordersList = await _orderSqLiteService.GetAllOrders();
        ViewData.Model = _ordersList;
        return View();
    }

    public IActionResult Add()
    {
        var curOrder = new Order() { ReceiptDate = DateTime.Today, CargoWeight = 0.2 };
        ViewData.Model = curOrder;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(Order curOrder)
    {
        
        if (ModelState.IsValid)
        {
            var id = Guid.NewGuid().ToString();
            curOrder.Id = id;
            await _orderSqLiteService.AddOrder(curOrder);
            return Redirect("~/Home/");
        }
        else
            return View(curOrder);
    }

    public async Task<IActionResult> DeleteOrder(string orderId)
    {
        await _orderSqLiteService.DeleteOrder(orderId);
        return Redirect("~/Home/");
    }

    public async Task<IActionResult> OrderDescription(string orderId)
    {
        var curOrder = await _orderSqLiteService.GetSingleOrder(orderId);
        ViewData.Model = curOrder;
        return View();
    }

}