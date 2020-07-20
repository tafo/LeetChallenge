using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Leet.July.AddBinary
{
    public class TestCase
    {
        public int MaxSize;
        public int ScanSize;
        public string LeftOperand;
        public string RightOperand;
        public string Expectation;
        public List<int> LeftDigits;
        public List<int> RightDigits;

        public TestCase(int maxSize = 4000, int scanSize = 30)
        {
            MaxSize = maxSize;
            LeftDigits = GetDigits();
            RightDigits = GetDigits();

            LeftOperand = string.Concat(LeftDigits);
            RightOperand = string.Concat(RightDigits);

            ScanSize = scanSize;
            var scannedCount = 0;
            int size;
            var carry = 0;
            do
            {
                size = 0;
                var leftPart = 0;
                var rightPart = 0;
                if (LeftDigits.Count > scannedCount)
                {
                    var digits = LeftDigits.SkipLast(scannedCount).TakeLast(scanSize).ToArray();
                    leftPart = digits.Length == 0 ? 0 : Convert.ToInt32(string.Concat(digits), 2);
                    size = digits.Length;
                }

                if (RightDigits.Count > scannedCount)
                {
                    var digits = RightDigits.SkipLast(scannedCount).TakeLast(scanSize).ToArray();
                    rightPart = digits.Length == 0 ? 0 : Convert.ToInt32(string.Concat(digits), 2);
                    size = Math.Max(size, digits.Length);
                }

                if (size == 0)
                {
                    if (carry == 1) Expectation = string.Concat('1', Expectation);
                }
                else
                {
                    var currentPart = Convert.ToString(leftPart + rightPart + carry, 2).PadLeft(size, '0');
                    carry = currentPart.Length - size;
                    Expectation = string.Concat(currentPart.Substring(carry), Expectation);
                    scannedCount += size;
                }
            } while (size > 0);
        }

        private List<int> GetDigits()
        {
            var length = Random.Next(1, MaxSize);
            var digits = new List<int> {1};
            for (var i = 1; i < length; i++)
            {
                digits.Add(Random.Next(0, 2));
            }

            return digits;
        }

        public static Random Random = new Random();
    }
}