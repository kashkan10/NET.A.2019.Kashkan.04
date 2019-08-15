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
            double left = d - right;
            string firstMantissaPart = GetLeftBin(left);
            string secondMantissaPart = GetRightBin(right, firstMantissaPart.Length);
            string exponent = GetExponent(1023 + count + firstMantissaPart.Length);

            return sign + exponent + firstMantissaPart + secondMantissaPart;
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
            while (num > 9)
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
        /// <returns>Returns the exponent</returns>
        private static char GetSign(double num)
        {
            return num < 0 ? '1' : '0';
        }
        /// <summary>
        /// Calculation of the first mantissa part
        /// </summary>
        /// <param name="num"></param>
        /// <returns>Returns first part of mantissa</returns>
        private static string GetLeftBin(double num)
        {
            StringBuilder result = new StringBuilder();
            while (num > 0)
            {
                result.Insert(0, num % 2);
                num = num / 2 - (num / 2 % 1);
            }

            return result.ToString().Remove(0, 1);
        }
        /// <summary>
        /// Calculation of the second mantissa part
        /// </summary>
        /// <param name="num"></param>
        /// <param name="leng">The length of first mantissa part</param>
        /// <returns>Returns second part of mantissa</returns>
        private static string GetRightBin(double num, int leng)
        {
            char[] arr = new char[52 - leng];
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
