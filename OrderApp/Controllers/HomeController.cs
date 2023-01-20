using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrderApp.Models;
using OrderApp.Services;

namespace OrderApp.Controllers;

public class HomeController : Controller
{
    private OrderService _orderSerivce;
    private List<OrderClientDTO> _ordersList;

    public HomeController(OrderService orderService)
    {
        _orderSerivce = orderService;
    }

    public async Task<IActionResult> Index()
    {
        _ordersList = await _orderSerivce.GetAllOrders();
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
            await _orderSerivce.AddOrder(curOrder);
            return Redirect("~/Home/");
        }
        else
            return View(curOrder);
    }

    public async Task<IActionResult> DeleteOrder(string orderId)
    {
        await _orderSerivce.DeleteOrder(orderId);
        return Redirect("~/Home/");
    }

    public async Task<IActionResult> OrderDescription(int orderUserId)
    {
        var curOrder = await _orderSerivce.GetSingleOrder(orderUserId);
        if (curOrder == null)
            return Redirect("~/Home/");
        ViewData.Model = curOrder;
        return View();
    }

}