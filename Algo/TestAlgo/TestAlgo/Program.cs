using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgo
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] a = { 1, 8, 7 };

            //int[] a = { 0,-1,-1,0,1 };
            //PrintArray(a);
            //QuickSort(a, 0, a.Length - 1);
            //Console.WriteLine("After Sort");
            //    PrintArray(a);
            //Console.ReadLine();

            //int[] a = { 1,0, -1, -1, 0, 1 };
            //PrintArray(a);
            //QuickSort3ElementArray(a, 0, a.Length - 1);
            //Console.WriteLine("After Sort");
            //PrintArray(a);
            //Console.ReadLine();

            //SumOf2inArray.printpairs(a, 15);

            int n = 15;
            Console.WriteLine(n);
            PrintPatterntWihtoutLoop.printPattrern(n, n, false,true);

           Console.ReadLine();
        }

        private static void QuickSort(int[] a, int start, int end)
        {
            if(start<end)
            {
                int pIndex = Partition(a, start, end);
                QuickSort(a, 0, pIndex - 1);
                QuickSort(a, pIndex + 1, end);
            }
           

        }

        private static int Partition(int[] a, int start, int end)
        {
            int pivot = a[end];
            int pIndex = start;
            for (int i= start;i <= end - 1;i++)
            {
                if(a[i]<= pivot)
                {
                    int temp = a[i];
                    a[i] = a[pIndex];
                    a[pIndex] = temp;
                    pIndex = pIndex + 1;
                }
                
            }

            int temp1 = a[pIndex];
            a[pIndex] = a[end];
            a[end] = temp1;

            Console.WriteLine("\n Intermediate Array With Pivot" + pivot);
            PrintArray(a);  
            return pIndex;

            
        }

   
        private static void PrintArray(int[] a)
        {
            for (int i = 0; i <= a.Length-1; i++)

                Console.Write(a[i] + "  ");

        }

        private static void QuickSort3ElementArray(int[] a, int start, int end)
        {
            if (start < end)
            {
                int pIndex = Partition3ElementArray(a, start, end,0);
                //QuickSort(a, 0, pIndex - 1);
                //QuickSort(a, pIndex + 1, end);
            }


        }

        private static int Partition3ElementArray(int[] a, int start, int end, int pivotprivided)
        {
            int pivot = pivotprivided;
            int pIndex = start;
            for (int i = start; i <=end; i++)
            {
                if (a[i] <= pivot)
                {
                    int temp = a[i];
                    a[i] = a[pIndex];
                    a[pIndex] = temp;
                    pIndex = pIndex + 1;
                }

            }

            int temp1 = a[pIndex];
            a[pIndex] = a[end];
            a[end] = temp1;

            Console.WriteLine("\n Intermediate Array With Pivot" + pivot);
            PrintArray(a);
            return pIndex;


        }

    }
}
