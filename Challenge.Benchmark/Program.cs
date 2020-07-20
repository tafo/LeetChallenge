using System;
using BenchmarkDotNet.Running;

namespace Challenge.Benchmark
{
    internal class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run(typeof(Leet.July.BaseToPower.Solution).Assembly);
            Console.ReadLine();
        }
    }
}
