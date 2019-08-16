using System;
using System.Diagnostics;
using System.Linq;

namespace GCD
{
    public class Euclid
    {
        /// <summary>
        /// Euclidian method of searching GCD
        /// </summary>
        /// <param name="arr">Array of integer numbers.</param>
        /// <returns>GCD of numbers</returns>
        public static int GCD(params int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    arr[i] = arr.Max();
                }
                arr[i] = Math.Abs(arr[i]);
            }

            int min = arr.Min();
            if (min == 0)
            {
                return 0;
            }

            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % min != 0)
                {
                    arr[i] %= min;
                }
                else
                {
                    count++;
                }
            }

            if (count == arr.Length)
            {
                return Math.Abs(min);
            }

            return GCD(arr);
        }

        /// <summary>
        /// Additional method to check calculation speed of GCD method
        /// </summary>
        /// <param name="arr">Array of integer numbers.</param>
        /// <returns>GCD of numbers</returns>
        public static int GCDWithTime(params int[] arr)
        {
            Stopwatch time = Stopwatch.StartNew();
            int result = GCD(arr);
            time.Stop();
            Console.WriteLine(time.Elapsed.TotalMilliseconds);

            return result;
        }
    }
}
