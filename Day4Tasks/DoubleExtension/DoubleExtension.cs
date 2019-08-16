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
            if (double.IsInfinity(d))
            {
                if (double.IsNegativeInfinity(d))
                {
                    return new string('1', 12) + new string('0', 52);
                }
                else
                {
                    return 0 + new string('1', 11) + new string('0', 52);
                }
            }

            if (double.IsNaN(d))
            {
                return new string('1', 13) + new string('0', 51);
            }

            if (d == 0)
            {
                if (double.IsNegativeInfinity(1.0 / d))
                {
                    return 1 + new string('0', 63);
                }
                else return new string('0', 64);
            }

            char sign = GetSign(d);
            d = Math.Abs(d);
            int exponentPart = 0;
            double copyOfSource = d;
            d = GetNormalize(d, ref exponentPart);

            if (Math.Abs(exponentPart) > 1023)
            {
                exponentPart = Math.Abs(exponentPart) - 1023;
                return sign + GetExponent(0) + GetDenormMantissa(copyOfSource, exponentPart);
            }

            double right = d % 1;
            string mantissa = GetMantissa(right);
            string exponent = GetExponent(1023 + exponentPart);

            return sign + exponent + mantissa;
        }

        /// <summary>
        /// Mantissa for the denormal number
        /// </summary>
        /// <param name="num">Source number</param>
        /// <param name="count">Abs exponent value</param>
        /// <returns>Normalized number</returns>
        private static string GetDenormMantissa(double num, int count)
        {
            StringBuilder tempResult = new StringBuilder();
            while (true)
            {
                if (num == 0)
                {
                    break;
                }

                num *= 2;
                if (num < 1)
                {
                    tempResult.Insert(tempResult.Length, '0');
                }
                else
                {
                    tempResult.Insert(tempResult.Length, '1');
                    num -= 1;
                }
            }

            string result = tempResult.ToString();
            result = result.Remove(0, result.IndexOf('1'));
            return new string('0', count) + tempResult + new string('0', 52 - tempResult.Length - count);
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
