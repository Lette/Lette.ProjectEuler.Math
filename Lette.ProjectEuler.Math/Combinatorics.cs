using System.Collections.Generic;
using System.Linq;
using Lette.ProjectEuler.Math.Extensions;

namespace Lette.ProjectEuler.Math
{
    public static class Combinatorics
    {
        public static IEnumerable<IEnumerable<int>> Pick(this int n, int k)
        {
            var v = new int[n];

            for (var i = 0; i < k; i++)
            {
                v[i] = 1;
            }

            yield return GetIndices(v, n);

            if (n == k || n == 0)
            {
                yield break;
            }

            while (true)
            {
                // find last "0"
                var position = -1;
                var ones = 1;

                for (var i = n - 1; i >= 0; i--)
                {
                    if (v[i] == 1)
                    {
                        ones++;
                    }

                    if (v[i] == 0)
                    {
                        position = i;
                        break;
                    }
                }

                // find last "1" before last "0"
                for (var i = position - 1; i >= 0; i--)
                {
                    if (v[i] == 1)
                    {
                        position = i;
                        break;
                    }
                }

                if (v[position] == 0)
                {
                    yield break;
                }

                v[position] = 0;

                for (var i = position + 1; i <= position + ones; i++)
                {
                    v[i] = 1;
                }

                for (var i = position + ones + 1; i < n; i++)
                {
                    v[i] = 0;
                }

                yield return GetIndices(v, n);
            }
        }

        private static IEnumerable<int> GetIndices(int[] v, int n)
        {
            var indices = new List<int>();
            for (var i = 0; i < n; i++)
            {
                if (v[i] == 1)
                {
                    indices.Add(i);
                }
            }
            return indices;
        }

        public static IEnumerable<long> Permutations(this long number)
        {
            return number
                .Digits()
                .Permutations()
                .Select(p => p.Aggregate((acc, i) => 10L * acc + i));
        }

        public static IEnumerable<IList<T>> Permutations<T>(this IEnumerable<T> sequence)
        {
            return Permutations(sequence.ToList());
        }

        public static IEnumerable<IList<T>> Permutations<T>(this IList<T> sequence)
        {
            if (sequence.Count <= 1)
            {
                yield return sequence;
                yield break;
            }

            for (var i = 0; i < sequence.Count; i++)
            {
                var head = sequence[i];
                var tail = new List<T>(sequence);
                tail.RemoveAt(i);

                var tailPermutations = tail.Permutations();

                foreach (var tailPermutation in tailPermutations)
                {
                    var permutation = new List<T>(sequence.Count) { head };
                    permutation.AddRange(tailPermutation);

                    yield return permutation;
                }
            }
        }
    }
}