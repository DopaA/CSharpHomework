using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入a添加商品");
            Console.WriteLine("输入d删除商品");
            Console.WriteLine("输入m修改商品");
            Console.WriteLine("输入f1通过编号查询商品");
            Console.WriteLine("输入f2通过商品名称查询商品");
            Console.WriteLine("输入f3通过客户查询商品");
            Console.WriteLine("输入exit退出");
            OrderDetails orderDetails = new OrderDetails();
            try
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (s == "exit") { break; }
                    orderDetails.function(s);
                    Console.WriteLine("你可以通过指令继续操作:");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("出现了异常:{0} ", e.Message);
            }
            Console.ReadLine();
        }
    }
}
