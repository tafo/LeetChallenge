using System.Diagnostics.CodeAnalysis;

namespace Challenge.Leet.July.BaseToPower
{
    /// <summary>
    /// 
    /// TITLE
    ///
    ///     Pow(b,n)
    ///
    /// DESCRIPTION
    /// 
    ///     Implement pow(b, n), which calculates b raised to the power n (xn).
    ///
    /// EXAMPLES
    ///
    ///     Example 1:
    ///     Input: 2.00000, 10
    ///     Output: 1024.00000
    /// 
    ///     Example 2:
    ///     Input: 2.10000, 3
    ///     Output: 9.26100
    ///
    ///     Example 3:
    ///     Input: 2.00000, -2
    ///     Output: 0.25000
    ///     Explanation: 2-2 = 1/22 = 1/4 = 0.25
    /// 
    /// NOTE
    ///
    ///     -100.0 < b < 100.0
    ///     n is a 32-bit signed integer, within the range [−2^31, 2^31 − 1]
    ///
    /// REMARKS
    /// 
    ///     [−2^31, 2^31 − 1] = [int.MinValue >> 1, int.MaxValue >> 1]
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "SuggestVarOrType_BuiltInTypes")]
    public class Solution
    {
        public double Power(double x, int n)
        {
            double result = 1.0;
            int power = n;
            while (power != 0)
            {
                if ((power & 1) == 1)
                {
                    result *= x;
                }

                power /= 2;
                x *= x;
            }

            return n < 0 ? 1 / result : result;
        }
    }
}