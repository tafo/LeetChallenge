using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Challenge.Leet.July.AddBinary
{
    /// <summary>
    ///
    /// TITLE
    ///
    ///     Add Binary
    ///
    /// DESCRIPTION
    ///
    ///     Given two binary strings, return their sum (also a binary string).
    ///
    ///     The input strings are both non-empty and contains only characters 1 or 0.
    ///
    ///     Example 1
    ///
    ///         Input: a = "11", b = "1"
    ///         Output: "100"
    ///
    ///     Example 2
    ///
    ///         Input: a = "1010", b = "1011"
    ///         Output: "10101"
    ///
    /// CONSTRAINTS
    ///
    ///     Each string consists only of '0' or '1' characters.
    ///     1 <= a.length, b.length <= 10^4
    ///     Each string is either "0" or doesn't contain any leading zero.
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public class Solution
    {
        /// <summary>
        /// Runtime: 108 ms
        /// Memory Usage: 26.9 MB
        /// </summary>
        public string AddBinaryByConvert(string a, string b)
        {
            var result = string.Empty;
            var leftDigits = a.Select(x => x - '0').ToList();
            var rightDigits = b.Select(x => x - '0').ToList();
            
            // The max integer is 31 bit.
            // (30 bit + 30 bit) <= 31 bit
            const int scanSize = 30;
            var scannedCount = 0;
            var carry = 0;
            int size;
            do
            {
                size = 0;
                var leftPart = 0;
                var rightPart = 0;
                if (leftDigits.Count > scannedCount)
                {
                    var digits = leftDigits.SkipLast(scannedCount).TakeLast(scanSize).ToArray();
                    leftPart = digits.Length == 0 ? 0 : Convert.ToInt32(string.Concat(digits), 2);
                    size = digits.Length;
                }

                if (rightDigits.Count > scannedCount)
                {
                    var digits = rightDigits.SkipLast(scannedCount).TakeLast(scanSize).ToArray();
                    rightPart = digits.Length == 0 ? 0 : Convert.ToInt32(string.Concat(digits), 2);
                    size = Math.Max(size, digits.Length);
                }

                if (size == 0)
                {
                    if (carry == 1) result = string.Concat('1', result);
                }
                else
                {
                    var currentPart = Convert.ToString(leftPart + rightPart + carry, 2).PadLeft(size, '0');
                    carry = currentPart.Length - size;
                    result = string.Concat(currentPart.Substring(carry), result);
                    scannedCount += size;
                }

            } while (size > 0);

            return result;
        }
    }
}