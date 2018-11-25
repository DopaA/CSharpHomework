using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apdo_homeowork_10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            Order order = new Order("11111111110", "pen", "123-2312-2423", 12,13);

            orderService.Add(order);
            orderService.Delete("11111111113");
        }
    }
}
