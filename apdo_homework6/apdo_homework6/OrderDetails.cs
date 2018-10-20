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
namespace Order
{
    class OrderDetails
    {
        int numOfOrder = 0;
        string sName;
        string sPerson;
        int count;
        public OrderService orderService = new OrderService();
        public int function(string inp)
        {
            if (inp == "a")
            {
                Console.WriteLine("请输入商品名称:");
                sName = Console.ReadLine();
                Console.WriteLine("请输入你的名字：");
                sPerson = Console.ReadLine();
                Console.WriteLine("请输入商品数量：");
                string s = Console.ReadLine();
                count = Int32.Parse(s);
                Order order = new Order(numOfOrder, sName, sPerson, count, 10001);
                orderService.addOrder(order);
                numOfOrder++;
            }
            else if (inp == "d")
            {
                Console.WriteLine("请输入商品名称：");
                sName = Console.ReadLine();
                int t = orderService.GetNumByName(sName);
                if (t == -1)
                {
                    throw new NameException("没有这样的商品名！");
                }
                orderService.deleteOrder(sName);
                numOfOrder--;
            }
            else if (inp == "m")
            {
                Console.WriteLine("请输入要修改的商品名称：");
                sName = Console.ReadLine();
                int t = orderService.GetNumByName(sName);
                if (t == -1)
                {
                    throw new NameException("没有这样的商品名！");
                }
                Console.WriteLine("请输入修改后的商品名称:");
                sName = Console.ReadLine();
                Console.WriteLine("请输入修改后的你的名字：");
                sPerson = Console.ReadLine();
                Console.WriteLine("请输入修改后的商品数量：");
                string s = Console.ReadLine();
                count = Int32.Parse(s);
                Order order = new Order(t, sName, sPerson, count, 50);
                orderService.modifyOrder(t, order);
            }
            else if (inp == "f1")
            {
                Console.WriteLine("输入你要查询的订单号:");
                string s = Console.ReadLine();
                int t = Int32.Parse(s);
                orderService.findByOrder(t);
            }
            else if (inp == "f2")
            {
                Console.WriteLine("输入你要查询的商品名：");
                string s = Console.ReadLine();
                orderService.findByName(s);
            }
            else if (inp == "f3")
            {
                Console.WriteLine("输入你要查询的客户：");
                string s = Console.ReadLine();
                orderService.findByPerson(s);
            }
            else if (inp == "f4")
            {
                Console.WriteLine("输入你要查询的最低价格：");
                string s = Console.ReadLine();
                int x = Int32.Parse(s);
                orderService.findByPrice(x);
            }
            else
            {
                Console.WriteLine("错误的指令！");
            }
            List<Order> orders = orderService.getOrders();
            Export(orders);
            //orderService.orders = Import();
            return 0;
        }
        public class NameException : ApplicationException
        {
            public NameException(string message) : base(message) { }
        }
        //Export方法，将所有订单序列化为xml文件
        public static void Export(List<Order> orders)
        {
            XmlSerializer xmlOrderservice = new XmlSerializer(typeof(List<Order>));
            string xmlFileName = "C:\\Users\\doapc\\Desktop\\Order.xml";
            XmlSerialize(xmlOrderservice, xmlFileName, orders);
        }
        public static void XmlSerialize(XmlSerializer ser, string filename, object obj)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }
        //Import方法，从xml中载入订单
        public List<Order> Import()
        {
            XmlSerializer xmlOrderservice = new XmlSerializer(typeof(List<Order>));
            string xmlFileName = "C:\\Users\\doapc\\Desktop\\Order.xml";
            FileStream fs = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read);
            List<Order> orders = (List<Order>)xmlOrderservice.Deserialize(fs);
            return orders;
        }
    }
}
