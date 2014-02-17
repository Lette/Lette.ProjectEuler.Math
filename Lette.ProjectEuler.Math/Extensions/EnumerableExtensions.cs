using System;
using System.Collections.Generic;

namespace Lette.ProjectEuler.Math.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Yield<T>(params T[] values)
        {
            return values;
        }

        public static IEnumerable<T> Plus<T>(this T first, T second)
        {
            yield return first;
            yield return second;
        }

        public static IEnumerable<T> Plus<T>(this IEnumerable<T> list, T value)
        {
            foreach (var item in list)
            {
                yield return item;
            }

            yield return value;
        }

        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var item in sequence)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T, long> action)
        {
            var index = 0L;

            foreach (var item in sequence)
            {
                action(item, index++);
            }
        }

        public static IEnumerable<TResult> Scan<T, TResult>(
            this IEnumerable<T> sequence, Func<TResult, T, TResult> aggregator, TResult seed = default(TResult))
        {
            var aggregate = seed;

            foreach (var item in sequence)
            {
                aggregate = aggregator(aggregate, item);
                yield return aggregate;
            }
        }

        public static T MaxBy<T, TProperty>(this IEnumerable<T> sequence, Func<T, TProperty> selector)
            where T : class
            where TProperty : IComparable<TProperty>
        {
            T maxItem = null;
            TProperty maxProperty = default(TProperty);

            var enumerator = sequence.GetEnumerator();

            if (enumerator.MoveNext())
            {
                maxItem = enumerator.Current;
                maxProperty = selector(maxItem);
            }

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                var property = selector(item);

                if (property.CompareTo(maxProperty) > 0)
                {
                    maxItem = item;
                }
            }

            if (maxItem == null)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }

            return maxItem;
        }
    }
}