using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

//订单的输入操作
namespace Orders
{
    public class OrderDetails
    {
        public int numOfOrder = 0;
        public string numstring;
        public string sName;
        public string sPerson;
        public int count;
        public OrderService orderService = new OrderService();
        //新建order的函数
        public Order func()
        {
            numstring = numOfOrder.ToString();
            Order order = new Order(numstring, sName, sPerson, count, 10001);
            numOfOrder++;
            return order;
        }
        //public int function(string inp)
        //{
        //    if (inp == "a")
        //    {
        //        Console.WriteLine("请输入商品名称:");
        //        sName = Console.ReadLine();
        //        Console.WriteLine("请输入你的名字：");
        //        sPerson = Console.ReadLine();
        //        Console.WriteLine("请输入商品数量：");
        //        string s = Console.ReadLine();
        //        count = Int32.Parse(s);
        //        Order order = new Order(numOfOrder, sName, sPerson, count, 10001);
        //        orderService.addOrder(order);
        //        numOfOrder++;
        //    }
        //    else if (inp == "d")
        //    {
        //        Console.WriteLine("请输入商品名称：");
        //        sName = Console.ReadLine();
        //        int t = orderService.GetNumByName(sName);
        //        if (t == -1)
        //        {
        //            throw new NameException("没有这样的商品名！");
        //        }
        //        orderService.deleteOrder(sName);
        //        numOfOrder--;
        //    }
        //    else if (inp == "m")
        //    {
        //        Console.WriteLine("请输入要修改的商品名称：");
        //        sName = Console.ReadLine();
        //        int t = orderService.GetNumByName(sName);
        //        if (t == -1)
        //        {
        //            throw new NameException("没有这样的商品名！");
        //        }
        //        Console.WriteLine("请输入修改后的商品名称:");
        //        sName = Console.ReadLine();
        //        Console.WriteLine("请输入修改后的你的名字：");
        //        sPerson = Console.ReadLine();
        //        Console.WriteLine("请输入修改后的商品数量：");
        //        string s = Console.ReadLine();
        //        count = Int32.Parse(s);
        //        Order order = new Order(t, sName, sPerson, count, 50);
        //        orderService.modifyOrder(t, order);
        //    }
        //    else if (inp == "f1")
        //    {
        //        Console.WriteLine("输入你要查询的订单号:");
        //        string s = Console.ReadLine();
        //        int t = Int32.Parse(s);
        //        orderService.findByOrder(t);
        //    }
        //    else if (inp == "f2")
        //    {
        //        Console.WriteLine("输入你要查询的商品名：");
        //        string s = Console.ReadLine();
        //        orderService.findByName(s);
        //    }
        //    else if (inp == "f3")
        //    {
        //        Console.WriteLine("输入你要查询的客户：");
        //        string s = Console.ReadLine();
        //        orderService.findByPerson(s);
        //    }
        //    else if (inp == "f4")
        //    {
        //        Console.WriteLine("输入你要查询的最低价格：");
        //        string s = Console.ReadLine();
        //        int x = Int32.Parse(s);
        //        orderService.findByPrice(x);
        //    }
        //    else
        //    {
        //        Console.WriteLine("错误的指令！");
        //    }
        //    //List<Order> orders = orderService.getOrders();
        //    //Export(orders);
        //    //orderService.orders = Import();
        //    return 0;
        //}
        public class NameException : ApplicationException
        {
            public NameException(string message) : base(message) { }
        }
      
    }
}
