using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperFractions
{
    public class Fractions
    {
        public static long ProperFractions(long n)
        {
            if (n < 3) return n-1;
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
            return fractions * 2;
        }

        public static List<long> FindFactors(long v)
        {
            if (v < 4) return new List<long>();
            var factors = new HashSet<long>();
            double squirt = (double)Math.Sqrt(v);
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

        public static long FindFractions(long denominator)
        {
            if (denominator == 1)
                return 0;
            long fractions = 0;
            var numStep = denominator % 2 == 0 ? 2 : 1;
            var divStep = denominator % 2 == 0 ? 1 : 2;
            for (long numerator = 1; numerator <= denominator / 2; numerator += numStep)
            {
                var isReducible = false;
                for (long divisor = 2; divisor <= numerator + divStep; divisor++)
                {
                    if (numerator % divisor == 0 && denominator % divisor == 0)
                    {
                        isReducible = true;
                        break;
                    }
                }
                if (!isReducible)
                    fractions++;
            }

            return fractions * 2;
        }

        public static long FindEven(long n)
        {
            if (n == 2) return 1;
            var factors = FindFactors(n);
            var fractionsList = new List<int>();
            var fractions = 0;
            for(var i=1; i<=n/2; i+=2)
            {
                if (factors.Contains(i)) continue;
                var iFactors = FindFactors(i);
                var commonFactors = factors.Where(f => iFactors.Contains(f)).Count();
                if (commonFactors > 0) continue;
                fractions++;
                fractionsList.Add(i);
            }
            return fractions*2;
        }

        public static long FindOdd(long n)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;
            List<long> factors = FindFactors(n);
            if (factors.Count == 0) return n - 1;
            var step = 1;
            if(n%2 == 0) step = 2;
            var fractionsList = new List<int>();
            var fractions = 0;
            for (var i=1; i<=n/2; i+=step)
            {
                if (factors.Contains(i)) continue;
                var iFactors = FindFactors(i);
                var commonFactors = factors.Where(f => iFactors.Contains(f)).Count();
                if (commonFactors > 0) continue;
                fractions++;
                fractionsList.Add(i);
            }
            return fractions*2;
        }
    }
}
