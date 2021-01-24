using System;

namespace Challenge.Leet.Twenty.July.BaseToPower
{
    public class TestCase
    {
        public TestCase(double baseNumber, int power)
        {
            Base = baseNumber;
            Power = power;
            Expectation = Math.Pow(baseNumber, power);
        }

        public double Base { get; set; }
        public int Power { get; set; }
        public double Expectation { get; set; }
    }
}