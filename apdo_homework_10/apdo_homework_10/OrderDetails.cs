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
        public class NameException : ApplicationException
        {
            public NameException(string message) : base(message) { }
        }

    }
}
