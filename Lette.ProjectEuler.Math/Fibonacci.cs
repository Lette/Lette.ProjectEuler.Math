using System.Collections.Generic;

namespace Lette.ProjectEuler.Math
{
    public class Fibonacci
    {
        public static IEnumerable<int> Sequence()
        {
            var i = 0;
            var j = 1;

            while (true)
            {
                var k = i + j;
                yield return k;
                i = j;
                j = k;
            }
// ReSharper disable FunctionNeverReturns
        }

// ReSharper restore FunctionNeverReturns
    }
}