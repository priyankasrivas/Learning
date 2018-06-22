using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgo
{
    static class SumOf2inArray
    {
        public static bool CheckSumOf2inArray(int[] a, int sumValue)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!(a[i] > sumValue))
                {
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (a[i] + a[j] == sumValue)
                        {
                            Console.WriteLine(a[i] + " and " + a[j]);
                            return true;
                        }
                    }
                }

            }
            return false;
        }

        public static void printpairs(int[] arr, int sum)
        {
            // Declares and initializes the whole array as false
            bool[] binmap = new bool[100];

            for (int i = 0; i < arr.Length; ++i)
            {
                int temp = sum - arr[i];

                // checking for condition
                if (temp >= 0 && binmap[temp])
                {
                   Console.WriteLine("Pair with given sum " +
                    sum + " is (" + arr[i] +
                    ", " + temp + ")");
                }
                binmap[arr[i]] = true;
            }
        }
    }
}
