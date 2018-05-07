using System;
using System.Threading.Tasks;

namespace AsyncApp
{
    class Program
    {
        static float perc = 1.2f;

        static void Main(string[] args)
        {
            var totalAfterTax = CalculateTotalAfterTaxAsync(70);

            Task.Delay(1).Wait();

            DoSomethingSynchronous();

            totalAfterTax.Wait();
            Console.ReadLine();
        }

        private static void DoSomethingSynchronous()
        {
            perc = 1.4f;
            Console.WriteLine("Doing some synchronous work");
        }

        static async Task<float> CalculateTotalAfterTaxAsync(float value)
        {
            Console.WriteLine("Started CPU Bound asynchronous task on a background thread");
            var result = await Task.Run(() => Calculate(value));
            Console.WriteLine($"Finished Task. Total of ${value} after tax of 20% is ${result} ");
            return result;
        }

        static float Calculate(float value)
        {
            float result = value;
            for (int i = 0; i < 100; i++)
            {
                result = value * perc;
                Console.WriteLine($"{i} {result}");
            }

            return result;
        }
    }
}