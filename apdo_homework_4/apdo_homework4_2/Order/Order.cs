using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//订单的组成部分,以及订单的生成
namespace Order
{
    class Order
    {
        private int OrderNum;//订单编号
        private string OrderName;//订单商品名
        private string OrderPerson;//订单的客户名
        private int OrderCount;//订单数量
        private int OrderPrice;//订单单个价格
        public Order(int OrderNum,string OrderName,string OrderPerson,int OrderCount,int OrderPrice)
        {
            this.OrderNum = OrderNum;
            this.OrderName = OrderName;
            this.OrderPerson = OrderPerson;
            this.OrderCount = OrderCount;
            this.OrderPrice = OrderPrice;
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
