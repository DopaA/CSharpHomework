using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//求指定数据的所有素数因子
namespace apdo_homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = " ";
            double inputNumber = 0;
            Console.Write("Please enter an int :");
            s = Console.ReadLine();
            inputNumber = Int32.Parse(s);
            double scale = Math.Sqrt(inputNumber);//最多到开方处
            int[] arrResult = new int[(int)inputNumber];
            arrResult[0] = 1;
            int counter = 1;
            for (int i = 2; i <= scale; i++)
            {
                double temp = inputNumber / i;
                if (temp == (int)temp)
                {
                    arrResult[counter] = i;
                    inputNumber = inputNumber / i;
                    counter++;
                    i = 1;
                }
            }
            if (inputNumber > 1)
            {
                arrResult[counter] = (int)inputNumber;
            }
            if (counter == 1)
            {
                arrResult[counter] = (int)inputNumber;
            }
            for(int i = 0; i < arrResult.Length; i++)
            {
                for(int j = i + 1; j < arrResult.Length; j++)
                {
                    if (arrResult[i] == arrResult[j])
                        arrResult[j] = 0;
                }
            }
            for(int i = 0; i < arrResult.Length; i++)
            {
                if (arrResult[i] == 0) break;
                Console.Write(arrResult[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
