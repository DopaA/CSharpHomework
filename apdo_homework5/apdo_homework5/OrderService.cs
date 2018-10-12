using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//订单的添加，删除，查找，修改操作
namespace Order
{
    class OrderService
    {
        List<Order> orders = new List<Order>();
        //添加订单
        public void addOrder(Order order)
        {
            orders.Add(order);
        }
        //删除订单
        public void deleteOrder(string sName)
        {
            foreach (Order o in orders)
            {
                if (o.Name == sName)
                    orders.Remove(o);
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
        public void findByOrder(int num)
        {
            var m = from o in orders where o.Num == num select o;
            foreach (var o in m)
            {
                    Console.Write(o.Num + "   " + o.Name + "  " + o.Person + "   " + o.Count + "    " + o.Price + "\n");
            }
        }
        //按商品名
        public void findByName(string name)
        {
            var m = from o in orders where o.Name == name select o;
            foreach (var o in m)
            {
                Console.Write(o.Num + "   " + o.Name + "  " + o.Person + "   " + o.Count + "    " + o.Price + "\n");
            }
        }
        //按客户
        public void findByPerson(string person)
        {
            var m = from o in orders where o.Person==person select o;
            foreach (var o in m)
            {
                Console.Write(o.Num + "   " + o.Name + "  " + o.Person + "   " + o.Count + "    " + o.Price + "\n");
            }
        }
        //查找大于某个金额的订单
        public void findByPrice(int price)
        {
            var m = from o in orders where o.Price >price select o;
            foreach (var o in m)
            {
                Console.Write(o.Num + "   " + o.Name + "  " + o.Person + "   " + o.Count + "    " + o.Price + "\n");
            }
        }
        //返回索引
        public int GetNumByName(string sName)
        {
            int i = 0;
            foreach (Order o in orders)
            {
                if (o.Name == sName)
                    return i;
                i++;
            }
            return -1;
        }
    }
}
