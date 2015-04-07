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


        private static readonly Dictionary<long, FactorCollection> FactorCollections = new Dictionary<long, FactorCollection>();

        public static FactorCollection Factorize(this long number)
        {
            long initNumber = number;
            if (FactorCollections.ContainsKey(initNumber))
                return FactorCollections[initNumber];

            FactorCollection results = new FactorCollection();
            int sqrt = (int)Math.Sqrt(number);
            for (int i = 0; i < PrimeManager.Primes.Count; i++)
            {
                if (number == 1)
                    break;
                if (PrimeManager.Primes[i] > sqrt)
                {
                    results.Add(new Factor { Prime = number, Cardinality = 1 });
                    number = 1;
                    break;
                }
                if (number % PrimeManager.Primes[i] == 0)
                {
                    results.Add(new Factor { Prime = PrimeManager.Primes[i], Cardinality = 1 });
                    number /= PrimeManager.Primes[i];
                }

                if (FactorCollections.ContainsKey(number))
                {
                    results = results.Append(FactorCollections[number]);
                    FactorCollections.Add(initNumber, results);
                    return results;
                }

                while (number % PrimeManager.Primes[i] == 0)
                {
                    results[results.Count - 1].Cardinality++;
                    number /= PrimeManager.Primes[i];
                }

            }
            if (number != 1)
            {
                results.Add(new Factor { Prime = number, Cardinality = 1 });
            }
            FactorCollections.Add(initNumber, results);
            return results;
        }

        public static FactorCollection Factorize(this int number)
        {
            return Factorize((long)number);
        }
    }
}
