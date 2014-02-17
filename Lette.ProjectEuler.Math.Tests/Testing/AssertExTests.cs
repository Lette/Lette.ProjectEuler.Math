using Xunit;
using Xunit.Sdk;

namespace Lette.ProjectEuler.Math.Tests.Testing
{
    public class AssertExTests
    {
        [Fact]
        public void Sequence_in_sequence_of_sequences_does_not_throw()
        {
            var sequenceOfSequences = new[] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 } };

            var expected = new[] { 2, 3 };

            Assert.DoesNotThrow(() => AssertEx.CollectionContainsNestedEquivalent(expected, sequenceOfSequences));
        }

        [Fact]
        public void Sequence_not_in_sequence_of_sequences_throws_DoesNotContainException()
        {
            var sequenceOfSequences = new[] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 } };

            var expected = new[] { 0 };

            Assert.Throws<DoesNotContainException>(() => AssertEx.CollectionContainsNestedEquivalent(expected, sequenceOfSequences));
        }
    }
}