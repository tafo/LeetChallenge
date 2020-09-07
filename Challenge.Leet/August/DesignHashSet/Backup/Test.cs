using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.August.DesignHashSet.Backup
{
    public class Test
    {
        private readonly ITestOutputHelper _testOutput;

        public Test(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Theory]
        [InlineData(1024 * 1024)]
        [InlineData(1024)]
        [InlineData(512)]
        [InlineData(256)]
        [InlineData(128)]
        [InlineData(64)]
        [InlineData(32)]
        [InlineData(16)]
        [InlineData(8)]
        [InlineData(4)]
        [InlineData(2)]
        [InlineData(1)]
        public void Check_TheHashSet(int max)
        {
            var keys = new List<int>();
            var random = new Random();
            for (var i = 0; i < max; i++)
            {
                var number = random.Next(0, max);
                keys.Add(number);
            }

            var timer = Stopwatch.StartNew();
            var set = new DesignHashSet.TheHashSet();
            foreach (var key in keys)
            {
                set.Add(key);
            }
            timer.Stop();
            _testOutput.WriteLine($"{timer.ElapsedTicks} ticks");
            _testOutput.WriteLine("Numbers");
            keys.ForEach(number => _testOutput.WriteLine($"{number}"));
            _testOutput.WriteLine("Set");
            foreach (var number in set.Root.NextDigits.Where(x => x != null))
            {
                WriteNumbers(string.Empty, number);
            }
            keys.ForEach(key => set.Contains(key).Should().BeTrue());

            void WriteNumbers(string num, Number number)
            {
                num = number.Digit + num;
                
                if (number.IsLastDigit)
                {
                    _testOutput.WriteLine(num);
                }

                if (number.NextDigits == null) return;

                foreach (var childNumber in number.NextDigits.Where(x => x != null))
                {
                    WriteNumbers(num, childNumber);
                }
            }
        }
    }
}