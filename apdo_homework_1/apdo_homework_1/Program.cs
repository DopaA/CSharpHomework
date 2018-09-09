using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apdo_homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int divisor_1 = 0, divisor_2 = 0;
            Console.Write("please enter a divisor:");
            s = Console.ReadLine();
            divisor_1 = Int32.Parse(s);
            Console.Write("please enter another divisor:");
            s = Console.ReadLine();
            divisor_2 = Int32.Parse(s);
            Console.WriteLine("the product of the two numbers is" + divisor_1 * divisor_2);
            Console.ReadLine();
        }
    }
}
