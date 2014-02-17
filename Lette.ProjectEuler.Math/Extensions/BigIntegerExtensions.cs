using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Lette.ProjectEuler.Math.Extensions
{
    public static class BigIntegerExtensions
    {
        public static BigInteger Sum(this IEnumerable<BigInteger> numbers)
        {
            return
                numbers.Aggregate(BigInteger.Zero, (i, j) => i + j);
        }

        public static BigInteger Choose(this BigInteger n, BigInteger k)
        {
            return n.Factorial() / (n - k).Factorial() / k.Factorial();
        }

        public static BigInteger Factorial(this BigInteger n)
        {
            return n == 0 ? 1 : n * (n - 1).Factorial();
        }

        public static BigInteger Pow(this BigInteger f, int e)
        {
            return BigInteger.Pow(f, e);
        }
    }
}