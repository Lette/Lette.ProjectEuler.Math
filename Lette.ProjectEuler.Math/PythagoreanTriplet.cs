using System;
using System.Collections.Generic;

namespace Lette.ProjectEuler.Math
{
    public class PythagoreanTriplet
    {
        public static IEnumerable<Tuple<long, long, long>> Sequence()
        {
            for (var v = 2;; v++)
            {
                for (var u = 1 + v % 2; u < v; u += 2)
                {
                    if (!Primes.IsCoprime(v, u))
                    {
                        continue;
                    }

                    var v2 = v * v;
                    var u2 = u * u;

                    var x = v2 - u2;
                    var y = 2 * u * v;
                    var z = v2 + u2;

                    if (x < y)
                    {
                        yield return new Tuple<long, long, long>(x, y, z);
                    }
                    else
                    {
                        yield return new Tuple<long, long, long>(y, x, z);
                    }
                }
            }
// ReSharper disable FunctionNeverReturns
        }

// ReSharper restore FunctionNeverReturns
    }
}