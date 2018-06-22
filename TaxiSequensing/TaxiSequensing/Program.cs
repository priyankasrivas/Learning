using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiSequensing
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid cabCompany1 = Guid.NewGuid();
            Guid cabCompany2 = Guid.NewGuid();
            Guid cabCompany3 = Guid.NewGuid();

            Dictionary<Guid, int> forcast = new Dictionary<Guid, int>();
            forcast.Add(cabCompany1, 100);
            forcast.Add(cabCompany2, 200);
            forcast.Add(cabCompany3, 300);
            Guid[] reuslt = new Guid[100];
            reuslt = GetSequence(forcast);

            foreach (var item in forcast)
            {
                int i = 1;
                Console.WriteLine($"CabCompany" + i.ToString() + ":" + item.Key.ToString() + " : " + item.Value);
            }
            foreach (var item in reuslt)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }


        private static Guid[] GetSequence(Dictionary<Guid, int> forecasts)
        {
            //Using list for convenience  and will convert to array when returning
            List<Guid> sequence = new List<Guid>();

            //This dictionary will save taxi provider guid and number of taxes  assigned to them in sequence
            Dictionary<Guid, int> TaxiAssigned = new Dictionary<Guid, int>();

            //Total of forecasts from all taxi providers
            int sumForeCast = forecasts.Sum(f => f.Value);

            //Assigning 1 taxi to each of the taxi providers, assuming each have 1 or more forecast otherwise will have validate here
            foreach (var item in forecasts)
            {
                sequence.Add(item.Key);
                TaxiAssigned.Add(item.Key, 1);


            }

            //Looping through to get 100 sequence
            for (int i = 0; i < 100; i++)
            {
                //Sum of currently assigned taxies 
                int sumAssignedTaxis = TaxiAssigned.Sum(f => f.Value);

                //check for next taxi only if needed
                if (sumAssignedTaxis < sumForeCast)
                {
                    //Get the taxi based on availability  %
                    Guid nextTaxi = GetNextTaxi(TaxiAssigned, forecasts);
                    sequence.Add(nextTaxi);

                    //Increment the assigned taxi number for cab provider
                    TaxiAssigned[nextTaxi] = TaxiAssigned[nextTaxi] + 1;
                }
            }

            return sequence.ToArray();
        }

        //find the best suited next taxi (sequence and fare utilization for all cab providers)
        private static Guid GetNextTaxi(Dictionary<Guid, int> TaxiAssigned, Dictionary<Guid, int> forecasts)
        {
            // Temp dictionary to store cab provider guid and utilization percentage
            Dictionary<Guid, double> temp = new Dictionary<Guid, double>();
            foreach (var item in TaxiAssigned)
            {
                //Only if more request to filled from this cab provider
                if (TaxiAssigned[item.Key] < forecasts[item.Key])
                {
                    temp.Add(item.Key, ((forecasts[item.Key] - item.Value) / (double)forecasts[item.Key]) * 100);
                }
            }

            KeyValuePair<Guid, double> max = new KeyValuePair<Guid, double>();
            foreach (var kvp in temp)
            {
                if (kvp.Value > max.Value)
                    max = kvp;
            }
            return max.Key;
        }
    }
}
