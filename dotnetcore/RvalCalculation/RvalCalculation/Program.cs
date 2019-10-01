using System;

namespace RvalCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            var phi1A = 4.0;
            var phi2A = 4.0; 
            var phi3A = 1.0;
            var phi1B = 21.0;
            var phi2B = 21.0; 
            var phi3B = 24.0;
            var values = new RValCalculationValues
            {
                Phi1A = phi1A,
                Phi2A = phi2A,
                Phi3A = phi3A,
                Phi1B = phi1B,
                Phi2B = phi2B,
                Phi3B = phi3B,
            };
            var rvalCalculator = new RValCalculator();
            var rval = rvalCalculator.CalculateRVal(values);
            Console.WriteLine($"rval: {rval}");
        }
    }
}