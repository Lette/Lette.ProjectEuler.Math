using System.Globalization;

namespace Lette.ProjectEuler.Math
{
    public static class Palindromes
    {
        public static bool IsPalindromic(this long num)
        {
            var s = num.ToString(CultureInfo.InvariantCulture);

            var i = 0;
            var j = s.Length - 1;

            for (; i < j;)
            {
                if (s[i++] != s[j--])
                {
                    return false;
                }
            }

            return true;
        }
    }
}