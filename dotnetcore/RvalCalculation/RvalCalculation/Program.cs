using System;
using MathNet.Numerics.LinearAlgebra.Double;

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
            var rValCalculator = new RValCalculator();
            var rVal = rValCalculator.CalculateRVal(values);
            Console.WriteLine($"rVal: {rVal}");
            
            
            var a = DenseMatrix.OfArray(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9.0 }
            });
            
            var b = DenseMatrix.OfArray(new[,]
            {
                { 11, 22, 53 },
                { 4, 54, 60 },
                { 1, 7, -2.0 }
            });

            var x = a * b;

//            var v1 = DenseVector.OfArray(new[] { 1.0, -21.3, 34.6});
//            var v2 = DenseVector.OfArray(new[] { 11.0, 56.3, 9.6});
//            var aNew = rValCalculator.Angle(v1, v2);
//            var aOld = rValCalculator.AngleOld(v1, v2);
//            Console.WriteLine($"new: {aNew}\nold:{aOld}");
        }
    }
}