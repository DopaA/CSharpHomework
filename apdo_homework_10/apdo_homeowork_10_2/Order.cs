using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apdo_homeowork_10_2
{

    [Serializable]
    public class Order
    {
        [Key]
        public string OrderNum { set; get; }//订单编号
        public string OrderName { set; get; }//订单商品名
        public string OrderPersonPhone { set; get; }//订单的客户名
        public int OrderCount { set; get; }//订单数量
        public int OrderPrice { set; get; }//订单单个价格
        public Order() { }
        public Order(string OrderNum, string OrderName, string OrderPersonPhone, int OrderCount, int OrderPrice)
        {
            this.OrderNum = OrderNum;
            this.OrderName = OrderName;
            this.OrderPersonPhone = OrderPersonPhone;
            this.OrderCount = OrderCount;
            this.OrderPrice = OrderPrice;
        }
        public override string ToString()
        {
            return OrderName + OrderNum + OrderPersonPhone + OrderCount + OrderPrice;
        }
    }
}
