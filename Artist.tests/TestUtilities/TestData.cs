using System;
using System.Linq;

namespace Artist.tests.TestUtilities
{
    public static class TestData
    {
        private static readonly Random _random = new Random();

        public static string CreateRandomString(int length = 16, int start = 97, int end = 122)
        {
            return Enumerable.Range(1, length)
                .Select(x => ((char) _random.Next(start, end)).ToString())
                .Aggregate((first, second) => $"{first}{second}");
        }
    }
}
