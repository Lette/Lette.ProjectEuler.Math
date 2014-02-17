using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace Lette.ProjectEuler.Math.Tests.Testing
{
    public static class AssertEx
    {
        public static void CollectionContainsNestedEquivalent<T>(IEnumerable<T> expectedSequence, IEnumerable<IEnumerable<T>> sequenceOfSequences)
        {
            foreach (var sequence in sequenceOfSequences)
            {
                try
                {
                    Assert.Equal(expectedSequence, sequence);
                    return;
                }
                catch (EqualException)
                {
                    // Keep trying...
                }
            }

            throw new DoesNotContainException(expectedSequence);
        }
    }
}