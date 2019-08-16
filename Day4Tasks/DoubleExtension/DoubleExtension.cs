using System;
using System.Text;

namespace DoubleExtension
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Convert the real number to IEEE 754
        /// </summary>
        /// <param name="d">Number to convert</param>
        /// <returns>String representation</returns>
        public static string DoubleToBin(this double d)
        {
            if (double.IsInfinity(d) || double.IsNaN(d))
            {
                if (double.IsNegativeInfinity(d) || double.IsNaN(d))
                {
                    return new string('1', 12) + new string('0', 52);
                }
                else
                {
                    return 0 + new string('1', 11) + new string('0', 52);
                }
            }

            if (d == 0)
            {
                if (double.IsNegativeInfinity(1.0 / d))
                {
                    return 1 + new string('0', 63);
                }
                else return new string('0', 64);
            }

            if (d == double.Epsilon)
            {
                return new string('0', 63) + 1;
            }

            char sign = GetSign(d);
            d = Math.Abs(d);
            int count = 0;
            d = GetNormalize(d, ref count);

            double right = d % 1;
            string mantissa = GetMantissa(right);
            string exponent = GetExponent(1023 + count);

            return sign + exponent + mantissa;
        }
        /// <summary>
        /// Normalization of source number
        /// </summary>
        /// <param name="num">Source number</param>
        /// <param name="count">Steps count</param>
        /// <returns>Normalized number</returns>
        private static double GetNormalize(double num, ref int count)
        {
            while (num < 1)
            {
                num *= 2;
                count--;
            }
            while (num >= 2)
            {
                num /= 2;
                count++;
            }

            return num;
        }
        /// <summary>
        /// Get the exponent in bin
        /// </summary>
        /// <param name="bias"></param>
        /// <returns>Returns the exponent</returns>
        private static string GetExponent(int bias)
        {
            Console.WriteLine(bias);
            StringBuilder result = new StringBuilder();

            while (bias > 0)
            {
                result.Insert(0, bias % 2);
                bias /= 2;
            }
            while (result.Length < 11)
            {
                result.Insert(0, 0);
            }
            return result.ToString();
        }
        /// <summary>
        /// Determine the sign of the number
        /// </summary>
        /// <param name="num">Source number</param>
        /// <returns>Returns the first sign</returns>
        private static char GetSign(double num)
        {
            return num < 0 ? '1' : '0';
        }
        /// <summary>
        /// Calculation of the mantissa 
        /// </summary>
        /// <param name="num"></param>
        /// <returns>Returns the mantissa</returns>
        private static string GetMantissa(double num)
        {
            char[] arr = new char[52];
            int i = 0;
            while (i < arr.Length)
            {
                if (num == 0)
                {
                    arr[i++] = '0';
                }
                else
                {
                    num *= 2;
                    if (num < 1)
                        arr[i++] = '0';
                    else
                    {
                        arr[i++] = '1';
                        num -= 1;
                    }
                }
            }

            return new string(arr);
        }
    }
}
