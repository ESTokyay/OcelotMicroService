using ShopiAPI.Models.OrderModels;
using System.Collections.Generic;

namespace ShopiAPI.Infrastructure
{
    public interface IOrderService
    {
        string OrderListSave(List<Order> orderList);
        object GetOrderList(OrderFilterModel orderFilter);
    }
}
