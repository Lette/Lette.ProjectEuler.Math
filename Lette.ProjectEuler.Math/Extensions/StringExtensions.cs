namespace Lette.ProjectEuler.Math.Extensions
{
    public static class StringExtensions
    {
        public static long ToLong(this string text)
        {
            return long.Parse(text);
        }
    }
}