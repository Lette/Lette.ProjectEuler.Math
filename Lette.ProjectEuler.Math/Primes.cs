using System;
using System.Collections.Generic;
using System.Linq;
using Lette.ProjectEuler.Math.Extensions;

namespace Lette.ProjectEuler.Math
{
    public static class Primes
    {
        // Increase _upperLimit to fit the needs of the problems
        // (will increase startup time)
        private const long _upperLimit = 20000000L;

        // The sieve will hold _upperLimit + 1 elements
        private static readonly bool[] _sieve;
        private static readonly Func<long, long>[] _eulerPhi = new Func<long, long>[1];

        static Primes()
        {
            //Console.Out.Write("Creating sieve...");
            _sieve = CreateSieve(_upperLimit);
            //Console.Out.WriteLine(" Done!");

            _eulerPhi[0] = n =>
                {
                    // Base case
                    if (n < 2)
                    {
                        return 0;
                    }

                    // Lehmer's conjecture
                    if (n.IsPrime())
                    {
                        return n - 1;
                    }

                    // Even number?
                    if ((n & 1) == 0)
                    {
                        var m = n / 2;
                        return (2 - (m & 1)) * _eulerPhi[0](m);
                    }

                    // For all primes ...
                    foreach (var p in Sequence())
                    {
                        var m = p;
                        if (n % m != 0)
                        {
                            continue;
                        }

                        // phi is multiplicative
                        var o = n / m;
                        var d = m.Gcd(o);
                        return d == 1
                            ? _eulerPhi[0](m) * _eulerPhi[0](o)
                            : _eulerPhi[0](m) * _eulerPhi[0](o) * d / _eulerPhi[0](d);
                    }

                    throw new InvalidOperationException();
                };

            _eulerPhi[0] = _eulerPhi[0].Memoize();

            _eulerPhi[0](1);
        }

        public static bool IsPrime(this long i)
        {
            if (i <= _upperLimit)
            {
                return (!_sieve[i]);
            }

            return i.IsPrimeSlow();
        }

        public static bool IsPrimeSlow(this long i)
        {
            // should be good up to _upperlimit^2
            return i.Factors().First() == i;
        }

        public static bool IsCoprime(long a, long b)
        {
            return a.Gcd(b) == 1L;
        }

        public static IEnumerable<long> Factors(this long i)
        {
            if (i < 2)
            {
                yield return i;
                yield break;
            }

            var limit = (long)System.Math.Floor(System.Math.Sqrt(i));

            foreach (var prime in Sequence(limit))
            {
                while (i % prime == 0)
                {
                    yield return prime;
                    i /= prime;

                    if (i == 1)
                    {
                        yield break;
                    }
                }
            }

            yield return i;
        }

        public static IEnumerable<long> Sequence()
        {
            return Sequence(_upperLimit);
        }

        public static IEnumerable<long> Sequence(long limit)
        {
            if (limit > _upperLimit)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (var i = 0L; i <= limit; i++)
            {
                if (!_sieve[i])
                {
                    yield return i;
                }
            }
        }

        public static IEnumerable<long> Divisors(this long i)
        {
            i = System.Math.Abs(i);
            var limit = i / 2;

            for (var d = 1L; d <= limit; d++)
            {
                if (i % d == 0)
                {
                    yield return d;
                }
            }

            yield return i;
        }

        public static IEnumerable<long> PrimeDivisors(this long i)
        {
            return i.Factors().Distinct();
        }

        public static long EulerPhi(this long i)
        {
            // Base case
            if (i < 2)
            {
                return 0;
            }

            // Lehmer's conjecture
            if (i.IsPrime())
            {
                return i - 1;
            }

            // Even number?
            if ((i & 1) == 0)
            {
                var m = i / 2;
                return (2 - (m & 1)) * m.EulerPhi();
            }

            // For all primes ...
            foreach (var p in Sequence())
            {
                var m = p;
                if (i % m != 0)
                {
                    continue;
                }

                // phi is multiplicative
                var o = i / m;
                var d = m.Gcd(o);
                return d == 1 ? m.EulerPhi() * o.EulerPhi() : m.EulerPhi() * o.EulerPhi() * d / d.EulerPhi();
            }

            throw new InvalidOperationException();
        }

        public static long EulerPhi2(this long i)
        {
            return _eulerPhi[0](i);
        }

        private static bool[] CreateSieve(long upperLimit)
        {
            var sieve = new bool[upperLimit + 1];

            sieve[0] = true;
            sieve[1] = true;

            var limit = (long)System.Math.Floor(System.Math.Sqrt(upperLimit));

            for (var i = 2L; i <= limit; i++)
            {
                if (sieve[i])
                {
                    continue;
                }

                var k = (upperLimit / i) - 1;

                for (var m = 1L; m <= k; m++)
                {
                    sieve[i * (m + 1)] = true;
                }
            }

            return sieve;
        }
    }
}