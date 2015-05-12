using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.VTotocevski
{
    class Problem9 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 9; }
        }

        public long Execute()
        {
            var broj = 0;
            for (var i = 1; i <= 1000; i++)
            {
                var ikocka = i * i;

                for (var j = 1; j <= 1000; j++)
                {
                    var jkocka = j * j;

                    if (i + j > 1000) break;

                    for (var k = 1; k <= (1000 - j - i); k++)
                    {
                        var kkocka = k * k;
                        var zbir = i + j + k;

                        if (ikocka + jkocka == kkocka && zbir == 1000)
                        {
                            broj = (i * j * k);
                            break;
                        }

                    }
                }
            }

            return broj;
        }
    }
}
