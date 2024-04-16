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
            return FindFractions(n);
        }
        public static long FindFractions(long denominator)
        {
            if(denominator == 1) 
                return 0;
            long fractions = 0;
            var numStep = denominator % 2 == 0 ? 2 : 1;
            var divStep = denominator % 2 == 0 ? 1 : 2;
            for(long numerator = 1; numerator<=denominator/2; numerator+=numStep)
            {
                var isReducible = false;
                for(long divisor = 2; divisor<=numerator+divStep; divisor++)
                {
                    if(numerator%divisor==0 && denominator % divisor == 0)
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
    }
}
