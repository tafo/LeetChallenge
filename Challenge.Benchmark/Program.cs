using System;
using BenchmarkDotNet.Running;

namespace Challenge.Benchmark
{
    internal class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run(typeof(July.BaseToPower.Solution).Assembly);
            Console.ReadLine();
        }
    }
}
