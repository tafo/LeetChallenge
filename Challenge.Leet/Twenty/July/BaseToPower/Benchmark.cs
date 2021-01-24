using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Challenge.Leet.Twenty.July.BaseToPower
{
    public class Benchmark
    {
        public readonly Test Test = new Test();
        public IEnumerable<object[]> BenchmarkSet { get; set; }
        public Solution Solution { get; set; }

        public Benchmark()
        {
            BenchmarkSet = Test.Tests.Select(x => new object[] { x.Base, x.Power }).ToList();
        }

        [Benchmark]
        [ArgumentsSource(nameof(BenchmarkSet))]
        public double RunCode(double x, int n)
        {
            return Solution.Power(x, n);
        }

        [Benchmark]
        [ArgumentsSource(nameof(BenchmarkSet))]
        public double RunMath(double x, int n)
        {
            return Math.Pow(x, n);
        }
    }
}