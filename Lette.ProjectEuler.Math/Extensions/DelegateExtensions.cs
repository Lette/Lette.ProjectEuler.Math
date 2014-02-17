using System;
using System.Collections.Generic;

namespace Lette.ProjectEuler.Math.Extensions
{
    public static class DelegateExtensions
    {
        public static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> func)
        {
            var dict = new Dictionary<T, TResult>();

            return n =>
                {
                    if (dict.ContainsKey(n))
                    {
                        return dict[n];
                    }

                    var result = func(n);
                    dict[n] = result;

                    return result;
                };
        }
    }
}