using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apdo_homework_2_1
{
    class Program
    {
        static int arrMax(int []arr)
        {
            int max = arr[0];
            for(int i = 1; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            return max;
        }
        static int arrMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                }
            }
            return min;
        }
        static double average(int [] arr)
        {
            double average = 0, sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            average = sum / arr.Length;
            return average;
        }
        static int sum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int[] arr = {1,5,6,8,45,2,52,52,5 };
            Console.WriteLine("the max is :" + arrMax(arr));
            Console.WriteLine("the min is :" + arrMin(arr));
            Console.WriteLine("the average is :" + average(arr));
            Console.WriteLine("the sum is :" + sum(arr));
            Console.ReadLine();
        }
    }
}
