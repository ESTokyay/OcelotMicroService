using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using ShopiAPI.Infrastructure;
using ShopiAPI.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ShopiAPI.Service.Shopi.API.Service
{
    public class OrderService : IOrderService
    {
        private readonly ShopiDbContext db;
        public OrderService(ShopiDbContext _db)
        {
            db = _db;
        }

        public object GetOrderList(OrderFilterModel orderFilter)
        {
            var orderProp=new List<string>();
            foreach (var properties in typeof(Order).GetProperties())
            {
                orderProp.Add(properties.Name);
            }

            bool propMevcutmu=orderProp.Contains(orderFilter.SortBy);

            if(propMevcutmu == false)
            {
                return new { hata = "Shortby Order sınıfında mevcut değil. Lütfen kontrol ediniz." };
            }

            var filter = $"orb.{orderFilter.SortBy}";            
            var orderList = db.Order.AsNoTracking().Where(w => orderFilter.Statuses.Contains(w.Status)
                                                            && (orderFilter.StartDate == null ? w.CreatedOn > DateTime.MinValue : w.CreatedOn > orderFilter.StartDate)
                                                            && (orderFilter.EndDate == null ? w.CreatedOn < DateTime.MaxValue : w.CreatedOn < orderFilter.EndDate))
                           .Take(orderFilter.PageSize).Skip(orderFilter.PageNumber * orderFilter.PageSize).OrderByDynamic(orb=>filter).ToList();

            return orderList;

        }

        public string OrderListSave(List<Order> orderList)
        {
            try
            {
                db.Order.AddRange(orderList);
                db.SaveChanges();

                return "Kayıt işlemi başarılı.";
            }
            catch (Exception e)
            {

                return "Kayıt işlemi gerçekleştirilemedi. Hata : " + e.Message;
            }

        }        

    }
}
