using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apdo_homeowork_10_2
{
    public class OrderService
    {

        public void Add(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Add(order);
                db.SaveChanges();
            }
        }
        public void Delete(string OrderNum)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.SingleOrDefault(o => o.OrderNum == OrderNum);
                db.Order.Remove(order);
                db.SaveChanges();
            }   
        }
        public Order GetOrder(String OrderNum)
        {
            using (var db = new OrderDB())
            {
                return db.Order.SingleOrDefault(o => o.OrderNum == OrderNum);
            }
        }
        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.Order.ToList<Order>();
            }
        }
    }
}
