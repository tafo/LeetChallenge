using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Collections;

namespace Challenge.Leet
{
    public static class PrivateExtensions
    {
        private static readonly Random Random = new Random();
        public static double Round(this double value)
        {
            return Math.Round(value, 5);
        }

        public static IEnumerable<int> Mix(this IEnumerable<int> set)
        {
            return set.OrderBy(x => Random.Next(-1, 2));
        }

        public static void BeEqualTo<T>(this GenericCollectionAssertions<T> set, IEnumerable<T> other)
        {
            set.BeEquivalentTo(other, options => options.WithStrictOrdering());
        }
    }
}