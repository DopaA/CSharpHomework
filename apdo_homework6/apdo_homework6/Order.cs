using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//订单的组成部分,以及订单的生成
namespace Order
{
    [Serializable]
    public class Order
    {
        public int OrderNum { set; get; }//订单编号
        public string OrderName { set; get; }//订单商品名
        public string OrderPerson { set; get; }//订单的客户名
        public int OrderCount { set; get; }//订单数量
        public int OrderPrice { set; get; }//订单单个价格
        public Order() { }
        public Order(int OrderNum, string OrderName, string OrderPerson, int OrderCount, int OrderPrice)
        {
            this.OrderNum = OrderNum;
            this.OrderName = OrderName;
            this.OrderPerson = OrderPerson;
            this.OrderCount = OrderCount;
            this.OrderPrice = OrderPrice;
        }
        public override string ToString()
        {
            return OrderName + OrderNum + OrderPerson + OrderCount + OrderPrice;
        }
        public int Num
        {
            get { return OrderNum; }
        }
        public string Name
        {
            get { return OrderName; }
        }
        public string Person
        {
            get { return OrderPerson; }
        }
        public int Count
        {
            get { return OrderCount; }
        }
        public int Price
        {
            get { return OrderPrice; }
        }
    }
}
