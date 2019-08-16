using System;
using System.Diagnostics;
using System.Linq;

namespace GCD
{
    public class Stein
    {
        /// <summary>
        /// Searching GCD of 1, 2, etc numbers with Steins algorithm
        /// </summary>
        /// <param name="arr">Array of integer numbers.</param>
        /// <returns>GCD of numbers</returns>
        public static int GCD(params int[] arr)
        {
            Stopwatch time = Stopwatch.StartNew();
            int a = Math.Abs(arr.First());
            int i = 1;
            while (i < arr.Length)
            {
                a = SteinAlgorithm(a, Math.Abs(arr[i++]));
            }

            time.Stop();
            Console.WriteLine(time.Elapsed.TotalMilliseconds);

            return a;
        }

        /// <summary>
        /// Stein's algorithm for two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="a">Second number</param>
        /// <returns>GCD of numbers</returns>
        private static int SteinAlgorithm(int a, int b)
        {
            if (a == b)
            {
                return a;
            }
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
            if (a == 1 || b == 1)
            {
                return 1;
            }
            if ((a & 1) == 0)
            {
                if ((b & 1) == 0)
                {
                    return SteinAlgorithm(a >> 1, b >> 1) << 1;
                }
                else
                {
                    return SteinAlgorithm(a >> 1, b);
                }
            }
            else
            {
                if ((b & 1) == 0)
                {
                    return SteinAlgorithm(a, b >> 1);
                }
                else
                {
                    return a > b ? SteinAlgorithm((a - b) >> 1, b) : SteinAlgorithm((b - a) >> 1, a);
                }
            }
        }
    }
}
