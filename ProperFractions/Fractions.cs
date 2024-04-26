using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperFractions
{
    public class Fractions
    {
        static public int FindFactorsCount = 0;
        static public int GCFCount = 0;

        public static long ProperFractions(long n)
        {
            //return FindFractions(n);
            return GCFMethod(n);
        }

        public static long FindFractions(long n)
        {
            if (n < 3) return n - 1;
            List<long> factors = FindFactors(n);
            if (!factors.Any()) return n - 1;
            var step = 1;
            if (n % 2 == 0) step = 2;
            var fractions = 0;
            for (var i = 1; i <= n / 2; i += step)
            {
                if (factors.Contains(i) || FindFactors(i).Where(f => factors.Contains(f)).Any()) continue;
                fractions++;
            }
            Console.WriteLine($"FindFactors count: {FindFactorsCount}");
            return fractions * 2;
        }

        public static List<long> FindFactors(long v)
        {
            FindFactorsCount++;
            if (v < 4) return new List<long>();
            var factors = new HashSet<long>();
            var squirt = Math.Sqrt(v);
            if (squirt%1==0) factors.Add((long)squirt);
            
            var step = v % 2 == 0 ? 1 : 2;
            for(long i = 1; i<squirt; i+=step)
            {
                if (v % i == 0)
                {
                    factors.Add(i);
                    factors.Add(v/i);
                }
            }
            factors.Remove(1);
            factors.Remove(v);
            return factors.OrderBy(f => f).ToList();
        }

        public static bool GreatestCommonFactor(long item1, long item2)
        {
            GCFCount++;
            if ((item1 % 2 == 0 && item2 % 2 == 0)|| (item1 % 3 == 0 && item2 % 3 == 0)) return true;
            for(long i = 5; i<=item2; i+=6)
            {
                if ((item1 % i == 0 && item2 % i == 0)|| (item1 % (i + 2) == 0 && item2 % (i + 2) == 0))
                    return true;
            }
            return false;
        }

        public static long GCFMethod(long n)
        {
            var fractions = n/2;
            for(long i=n/2; i>0; i--)
            {
                if (GreatestCommonFactor(n, i)) 
                    fractions--;
            }
            Console.WriteLine($"GCF count: {GCFCount}");
            return fractions * 2;
        }
    }
}
