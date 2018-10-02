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
                if(o.Name==sName)
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
            bool bo = true;
            foreach (Order o in orders)
            {
                if (o.Num == num)
                {
                    Console.Write(o.Num + "   " + o.Name + "  " + o.Person + "   " + o.Count + "    " + o.Price + "\n");
                    bo = false;
                }
            }
            if (bo)
            {
                Console.WriteLine("没有所要查找的订单号！");
            }
        }
        //按商品名
        public void findByName(string name)
        {
            bool bo = true;
            foreach(Order o in orders)
            {
                if (o.Name == name)
                {
                    Console.Write(o.Num + "   " + o.Name + "  " + o.Person + "   " + o.Count + "    " + o.Price + "\n");
                    bo = false;
                }
            }
            if (bo)
            {
                Console.WriteLine("没有所要查找的商品名！");
            }
        }
        //按客户
        public void findByPerson(string person)
        {
            bool bo = true;
            foreach (Order o in orders)
            {
                if (o.Person == person)
                {
                    Console.Write(o.Num + "   " + o.Name + "  " + o.Person +"   "+ o.Count + "    " + o.Price + "\n");
                    bo = false;
                }
            }
            if (bo)
            {
                Console.WriteLine("没有所要查找的客户！");
            }
        }
        //返回索引
        public int GetNumByName(string sName)
        {
            int i = 0;
            foreach (Order o in orders)
            {
                if(o.Name==sName)
                return i;
                i++;
            }
            return -1;
        }
    }
}
