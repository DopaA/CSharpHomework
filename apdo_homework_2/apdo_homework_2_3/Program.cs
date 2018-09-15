using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apdo_homework_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrTemp = new double[99];
            for(int i = 2; i <= 100; i++)
            {
                arrTemp[i - 2] = i;
            }
            for(int i = 0; i < arrTemp.Length; i++)
            {
                for(int j = 2; j < 100; j++)
                {
                    if (arrTemp[i]%j==0 && arrTemp[i]!=j)
                    {
                        arrTemp[i] = 0;

                    }
                }
            }
            Console.WriteLine("all prime number between 2 and 100 are:");
            for(int i = 0; i < arrTemp.Length; i++)
            {
                if (arrTemp[i] != 0)
                {
                    Console.Write(arrTemp[i] + " ");
                }
            }
            Console.Read();
        }
    }
}
