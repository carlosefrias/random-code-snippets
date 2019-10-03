using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace RvalCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            var phi1A = 2.82;
            var phi2A = 4.07; 
            var phi3A = 2.45;
            
            var phi1B = 4.34;
            var phi2B = 1.67; 
            var phi3B = 38;
            var values = new RValCalculationValues
            {
                Phi1A = phi1A,
                Phi2A = phi2A,
                Phi3A = phi3A,
                Phi1B = phi1B,
                Phi2B = phi2B,
                Phi3B = phi3B,
            };
            var rValCalculator = new RValCalculator();
            var rVal = rValCalculator.CalculateRVal(values);
            Console.WriteLine($"rVal: {rVal}");
        }
    }
}