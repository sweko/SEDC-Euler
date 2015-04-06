using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.SWeko
{
    class PrimeManager
    {

        //private static HashSet<long> PrimesHash;
        //private static long LastPrime;

        public static List<long> Primes;
        //private static long[] PrimesArray;

        public static void GeneratePrimes(int limit)
        {
            var isPrime = new BitArray(limit + 1, false);
            var sqrt = (int)Math.Sqrt(limit);

            for (int x = 1; x <= sqrt; x++)
            {
                var xx = x * x;
                for (int y = 1; y <= sqrt; y++)
                {
                    var yy = y * y;
                    var n = 4 * xx + yy;
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                        isPrime[n] = !isPrime[n];

                    n = 3 * xx + yy;
                    if (n <= limit && n % 12 == 7)
                        isPrime[n] = !isPrime[n];

                    n = 3 * xx - yy;
                    if (x > y && n <= limit && n % 12 == 11)
                        isPrime[n] = !isPrime[n];
                }
            }

            Primes = new List<long> { 2, 3 };
            for (int n = 5; n <= sqrt; n++)
            {
                if (isPrime[n])
                {
                    Primes.Add(n);
                    int nn = n * n;
                    for (int k = nn; k <= limit; k += nn)
                        isPrime[k] = false;
                }
            }

            for (int n = sqrt + 1; n <= limit; n++)
                if (isPrime[n])
                {
                    Primes.Add(n);
                }
            //LastPrime = Primes[Primes.Count - 1];
            //PrimesArray = Primes.ToArray();
            //PrimesHash = new HashSet<long>(Primes);
        }

    }
}
