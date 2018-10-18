using System;

namespace FindRoot
{
    /// <summary>
    /// Class contains methods for finding number root.
    /// </summary>
    public static class RootFinder
    {
        /// <summary>
        /// Finding n root of user's number.
        /// </summary>
        /// <param name="number">User's number.</param>
        /// <param name="n">Root for calculations.</param>
        /// <param name="eps">Eps argument for calculations.</param>
        /// <returns>Returns n root of user's number.</returns>
        /// <exception cref="ArgumentNullException">Throws when passed arguments are not correct.</exception>
        public static double FindNthRoot(double number, int n, double eps)
        {
            if (number < 0 && n % 2 == 0)
            {
                throw new ArgumentException(nameof(number) + " is not  correct");
            }

            if (eps <= 0 || eps >= 1)
            {
                throw new ArgumentException(nameof(eps) + " is out of range");
            }

            if (n <= 0)
            {
                throw new ArgumentException("Root cat't be below 0");
            }

            return FindRoot(number, n, eps);
        }

        /// <summary>
        /// Checking rules and finding a root.
        /// </summary>
        /// <param name="number">User's number.</param>
        /// <param name="n">Root for calculations.</param>
        /// <param name="eps">Eps argument for calculations.</param>
        /// <returns>Returns n root of user's number.</returns>
        private static double FindRoot(double number, int n, double eps)
        {
            double result = number;
            double prevElem = 0;

            do
            {
                prevElem = result;
                result = (1.0 / n) * ((n - 1) * result + number / Math.Pow(result, n - 1));
            }
            while (Math.Abs(prevElem - result) > eps);

            return result;
        }
    }
}
