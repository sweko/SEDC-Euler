using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.SWeko
{
    public static class Extensions
    {
        public static int Power(this int baseNumber, int exponent)
        {
            return (int)Power((long)baseNumber, exponent);
        }

        public static long Power(this long baseNumber, int exponent)
        {
            checked
            {
                if (exponent == 0)
                    return 1;
                long result = 1;
                long multiplier = baseNumber;
                while (exponent > 1)
                {
                    if (exponent % 2 == 1)
                        result *= multiplier;
                    exponent /= 2;
                    multiplier *= multiplier;
                }
                result *= multiplier;
                return result;
            }
        }

        public static IEnumerable<long> GetDivisors(this int number)
        {
            return GetDivisors((long)number);
        }

        public static IEnumerable<long> GetDivisors(this long number)
        {
            List<Factor> primeFactors = number.Factorize();
            if (primeFactors.Count == 0)
            {
                yield return 1;
                yield break;
            }

            Factor firstFactor = primeFactors[0];
            number /= firstFactor.Prime.Power(firstFactor.Cardinality);

            for (int i = 0; i <= firstFactor.Cardinality; i++)
            {
                long init = firstFactor.Prime.Power(i);

                foreach (long div in number.GetDivisors())
                {
                    yield return div * init;
                }
            }
        }

        public static FactorCollection Factorize(this long number)
        {
            FactorCollection results = new FactorCollection();
            int sqrt = (int)Math.Sqrt(number);
            foreach (long prime in PrimeManager.Primes.TakeWhile(_ => number != 1))
            {
                if (prime > sqrt)
                {
                    results.Add(new Factor { Prime = number, Cardinality = 1 });
                    number = 1;
                    break;
                }

                if (number % prime != 0)
                    continue;

                Factor factor = new Factor { Prime = prime, Cardinality = 1 };
                number /= prime;
                while (number % prime == 0)
                {
                    factor.Cardinality++;
                    number /= prime;
                }
                results.Add(factor);
            }
            if (number != 1)
            {
                results.Add(new Factor { Prime = number, Cardinality = 1 });
            }
            return results;
        }

        public static FactorCollection Factorize(this int number)
        {
            return Factorize((long)number);
        }
    }
}
