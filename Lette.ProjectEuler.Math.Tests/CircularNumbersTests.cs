using Xunit;

namespace Lette.ProjectEuler.Math.Tests
{
    public class CircularNumbersTests
    {
        [Fact]
        public void Can_generate_circular_numbers_from_single_digit()
        {
            var seq = 5L.CircularNumbers();

            Assert.Equal(new[] { 5L }, seq);
        }

        [Fact]
        public void Can_generate_circular_numbers_from_double_digits()
        {
            var seq = 25L.CircularNumbers();

            Assert.Equal(new[] { 25L, 52L }, seq);
        }

        [Fact]
        public void Can_generate_circular_numbers_from_multiple_digits_with_embedded_zeroes()
        {
            var seq = 10305L.CircularNumbers();

            Assert.Equal(new[] { 10305L, 51030L, 05103L, 30510L, 03051L }, seq);
        }
    }
}