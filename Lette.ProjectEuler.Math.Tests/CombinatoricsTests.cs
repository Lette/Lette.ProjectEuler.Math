using System.Collections.Generic;
using System.Linq;
using Lette.ProjectEuler.Math.Tests.Testing;
using Xunit;

namespace Lette.ProjectEuler.Math.Tests
{
    public class CombinatoricsTests
    {
        [Fact]
        public void Permutation_of_the_empty_set_is_the_empty_set()
        {
            var originalSet = new int[] { };
            IEnumerable<IEnumerable<int>> permutations = originalSet.Permutations();

            Assert.Equal(1, permutations.Count());
            Assert.Equal(Enumerable.Empty<int>(), permutations.First());
        }

        [Fact]
        public void Permutations_of_a_set_with_one_element_is_a_set_of_that_set()
        {
            var originalSet = new[] { 1 };
            IEnumerable<IEnumerable<int>> permutations = originalSet.Permutations();

            Assert.Equal(1, permutations.Count());
            Assert.Equal(new[] { 1 }, permutations.First());
        }

        [Fact]
        public void Permutations_of_a_set_with_two_elements_is_a_set_of_two_sets()
        {
            var originalSet = new[] { 1, 2 };
            IEnumerable<IEnumerable<int>> permutations = originalSet.Permutations().ToList();

            Assert.Equal(2, permutations.Count());
            AssertEx.CollectionContainsNestedEquivalent(new[] { 1, 2 }, permutations);
            AssertEx.CollectionContainsNestedEquivalent(new[] { 2, 1 }, permutations);
        }

        [Fact]
        public void Permutations_of_a_set_with_three_elements_is_a_set_of_six_sets()
        {
            var originalSet = new[] { 1, 2, 3 };
            IEnumerable<IEnumerable<int>> permutations = originalSet.Permutations().ToList();

            Assert.Equal(6, permutations.Count());
            AssertEx.CollectionContainsNestedEquivalent(new[] { 1, 2, 3 }, permutations);
            AssertEx.CollectionContainsNestedEquivalent(new[] { 1, 3, 2 }, permutations);
            AssertEx.CollectionContainsNestedEquivalent(new[] { 2, 1, 3 }, permutations);
            AssertEx.CollectionContainsNestedEquivalent(new[] { 2, 3, 1 }, permutations);
            AssertEx.CollectionContainsNestedEquivalent(new[] { 3, 1, 2 }, permutations);
            AssertEx.CollectionContainsNestedEquivalent(new[] { 3, 2, 1 }, permutations);
        }

        [Fact]
        public void Single_digit_has_itself_as_the_only_permutation()
        {
            IEnumerable<long> permutations = 1L.Permutations();

            Assert.Equal(new[] { 1L }, permutations);
        }
    }
}