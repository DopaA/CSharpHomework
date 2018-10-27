using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//订单的添加，删除，查找，修改操作
namespace Orders
{
    public class OrderService
    {
        public List<Order> orders = new List<Order>();
        //添加订单
        public List<Order> getOrders()
        {
            return orders;
        }
        public void addOrder(Order order)
        {
            orders.Add(order);
        }
        //删除订单
        public void deleteOrder(string sName)
        {
            //使用foreach不能变动集合
            //foreach (Order o in orders)   
            //{
            //    if (o.Name == sName)
            //        orders.Remove(o);
            //}
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderName == sName)
                    orders.Remove(orders[i]);
            }
        }
        //改变订单内容
        public void modifyOrder(int num, Order order)
        {
            orders.RemoveAt(num);
            orders.Insert(num, order);
        }
        //查询订单
        //按订单号
        public bool findByOrder(int num)
        {
            var m = from o in orders where o.OrderNum == num select o;
            int i = 0;
            foreach (var o in m)
            {
                Console.Write(o.OrderNum + "   " + o.OrderName + "  " + o.OrderPerson + "   " + o.OrderCount + "    " + o.OrderPrice + "\n");
                i++;
            }
            if (i == 0) return false;
            else return true;
        }
        //按商品名
        public bool findByName(string name)
        {
            var m = from o in orders where o.OrderName == name select o;
            int i = 0;
            foreach (var o in m)
            {
                Console.Write(o.OrderNum + "   " + o.OrderName + "  " + o.OrderPerson + "   " + o.OrderCount + "    " + o.OrderPrice + "\n");
                i++;
            }
            if (i == 0) return false;
            else return true;
        }
        //按客户
        public bool findByPerson(string person)
        {
            var m = from o in orders where o.OrderPerson == person select o;
            int i = 0;
            foreach (var o in m)
            {
                Console.Write(o.OrderNum + "   " + o.OrderName + "  " + o.OrderPerson + "   " + o.OrderCount + "    " + o.OrderPrice + "\n");
                i++;
            }
            if (i == 0) return false;
            else return true;
        }
        //查找大于某个金额的订单
        public bool findByPrice(int price)
        {
            var m = from o in orders where o.OrderPrice > price select o;
            int i = 0;
            foreach (var o in m)
            {
                Console.Write(o.OrderNum + "   " + o.OrderName + "  " + o.OrderPerson + "   " + o.OrderCount + "    " + o.OrderPrice + "\n");
                i++;
            }
            if (i == 0) return false;
            else return true;
        }
        //返回索引
        public int GetNumByName(string sName)
        {
            int i = 0;
            foreach (Order o in orders)
            {
                if (o.OrderName == sName)
                    return i;
                i++;
            }
            return -1;
        }
    }
}
