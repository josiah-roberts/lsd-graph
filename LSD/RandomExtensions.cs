using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LSD
{
    static class RandomExtensions
    {
        public static double Gaussian(this Random randy, double mean, double stdDev)
        {
            double u, v, s;
            do
            {
                u = randy.NextDouble() * 2d - 1d;
                v = randy.NextDouble() * 2d - 1d;
                s = u * u + v * v;
            } while (s >= 1 || s == 0);
            double mul = Math.Sqrt(-2.0 * Math.Log(s) / s);
            return mean + stdDev * u * mul;
        }

        public static IEnumerable<TOut> Distinct<T, TOut>(this IEnumerable<T> input, Func<T, TOut> factory)
        {
            return input.Select(factory).Distinct();
        }
    }
}
