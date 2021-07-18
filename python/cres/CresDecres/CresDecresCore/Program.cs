using System;
using System.Collections.Generic;
using System.Linq;

namespace CresDecresCore
{
    internal static class Program
    {
        private static void Main()
        {
            var indices = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            var combinations = GetCombinations(indices, 6);

            var enumerable = combinations as IEnumerable<int>[] ?? combinations.ToArray();
            var listCrescent = enumerable
                .Where(elem => elem.FirstOrDefault() > 0)
                .Select(CalcNumberCrescent)
                .ToList();
            Console.WriteLine($"Ordem crescente {listCrescent.Count}");
            var listDeCrescent = enumerable
                .Select(CalcNumberDeCrescent)
                .ToList();
            Console.WriteLine($"Ordem decrescente {listDeCrescent.Count}");
            Console.WriteLine($"Total {listCrescent.Count + listDeCrescent.Count}");
        }
        
        private static IEnumerable<IEnumerable<int>> GetCombinations(IReadOnlyCollection<int> list, int length)
        {
            if (length == 1) return list.Select(t => new[] { t }).ToHashSet();

            return GetCombinations(list, length - 1)
                .SelectMany(t => list.Where(e => IsBiggerThanAllTheOthers(t, e)),
                    (t1, t2) => t1.Concat(new[] { t2 }));
        }

        private static bool IsBiggerThanAllTheOthers(IEnumerable<int> list, int val)
        {
            return list.All(elem => elem < val);
        }

        private static int CalcNumberCrescent(IEnumerable<int> values)
        {
            var result = 0;
            var first = true;
            foreach (var value in values)
            {
                if (!first)
                {
                    result *= 10;
                }
                else
                {
                    first = false;
                }
                result += value;
            }

            return result;
        }

        private static int CalcNumberDeCrescent(IEnumerable<int> values)
        {
            var reversed = values.Reverse();
            return CalcNumberCrescent(reversed);
        }
    }
}
