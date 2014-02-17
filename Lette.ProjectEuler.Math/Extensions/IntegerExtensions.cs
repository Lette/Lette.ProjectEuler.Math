using System;
using System.Collections.Generic;
using System.Linq;

namespace Lette.ProjectEuler.Math.Extensions
{
    public static class IntegerExtensions
    {
        public static IEnumerable<int> To(this int start, int stop)
        {
            while (start <= stop)
            {
                yield return start++;
            }
        }

        public static IEnumerable<long> To(this long start, long stop)
        {
            while (start <= stop)
            {
                yield return start++;
            }
        }

        public static IEnumerable<long> Digits(this long num)
        {
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (num == 0)
            {
                yield return 0;
                yield break;
            }

            while (num > 0)
            {
                var r = num % 10;
                yield return r;
                num -= r;
                num /= 10;
            }
        }

        public static long Multiply(this IEnumerable<long> numbers)
        {
            return
                numbers.Aggregate(1L, (i, j) => i * j);
        }

        public static long Choose(this long n, long k)
        {
            return n.Factorial() / (n - k).Factorial() / k.Factorial();
        }

        public static long Factorial(this long n)
        {
            return n == 0 ? 1 : n * (n - 1).Factorial();
        }

        public static long Gcd(this long a, long b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        public static long Lcm(this long a, long b)
        {
            return a * b / Gcd(a, b);
        }
    }
}