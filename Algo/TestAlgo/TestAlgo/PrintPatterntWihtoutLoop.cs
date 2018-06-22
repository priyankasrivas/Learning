using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgo
{
    class PrintPatterntWihtoutLoop
    {
        public static void printPattrern(int n, int currntValue, bool isRecursionCall, bool isDirectionDown)
        {
            if (n == currntValue && isRecursionCall)
            {
                return;
            }

            if (currntValue >= 0 && isDirectionDown)
            {
                currntValue = currntValue - 5;
                Console.WriteLine(currntValue);
                printPattrern(n, currntValue, true,true);
            }
            else
            {
                currntValue = currntValue + 5;
                Console.WriteLine(currntValue);
                printPattrern(n, currntValue, true, false);
            }

           
        }
    }
}

