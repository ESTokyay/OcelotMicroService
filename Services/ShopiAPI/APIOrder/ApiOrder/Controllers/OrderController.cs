using Microsoft.AspNetCore.Mvc;
using ShopiAPI.Infrastructure;
using ShopiAPI.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("OrdersSave")]
        public string OrdersSave(List<Order> orderList)
        {
            return _orderService.OrderListSave(orderList);
        }

        [HttpPost("GetOrderList")]
        public List<Order> GetOrderList(OrderFilterModel orderFilter)
        {
            foreach (var properties in typeof(Order).GetProperties())
            {
                Console.WriteLine(properties.Name);
            }
            return (List<Order>)_orderService.GetOrderList(orderFilter);
        }

        
    }
}
