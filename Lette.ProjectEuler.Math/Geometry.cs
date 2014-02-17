using System.Collections.Generic;

namespace Lette.ProjectEuler.Math
{
    public class Geometry
    {
        public static IEnumerable<long> TriangleNumbers()
        {
            var num = 0L;
            var inc = 1L;

            while (true)
            {
                yield return num += inc++;
            }
// ReSharper disable FunctionNeverReturns
        }

// ReSharper restore FunctionNeverReturns
    }
}