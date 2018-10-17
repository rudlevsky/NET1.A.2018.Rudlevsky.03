using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Numbers
{
    /// <summary>
    /// Class finds next bigger number.
    /// </summary>
    public static class Finder
    {
        /// <summary>
        /// Number passed by user.
        /// </summary>
        private static int userNumber;

        /// <summary>
        /// Check possible numbers and return next bigger number.
        /// </summary>
        /// <param name="number">User's number.</param>
        /// <returns>Next bigger number.</returns>
        public static int FindNextBiggerNumber(int number)
        {
            const int PossibleNumbers = 10;

            if (number < PossibleNumbers)
            {
                return -1;
            }

            return FindNumber(number);
        }

        /// <summary>
        /// Elements swapping.
        /// </summary>
        /// <param name="first">First element.</param>
        /// <param name="second">Second element.</param>
        private static void Swap(ref char first, ref char second)
        {
            char buf = first;
            first = second;
            second = buf;
        }

        /// <summary>
        /// Generates all possible numbers from elements of the array.
        /// </summary>
        /// <param name="currElem">Current element of the array.</param>
        /// <param name="chrArray">Array of the elements of the number.</param>
        /// <param name="list">Structure which contains number combinations.</param>
        private static void GenerteElems(int currElem, char[] chrArray, List<int> list)
        {
            int chrLength = chrArray.Length;

            if (currElem == chrLength)
            {
                var builder = new StringBuilder();
                builder.Append(chrArray);

                if (int.Parse(builder.ToString()) > userNumber)
                {
                    list.Add(int.Parse(builder.ToString()));
                }
            }
            else
            {
                for (int i = currElem; i < chrLength; i++)
                {
                    Swap(ref chrArray[currElem], ref chrArray[i]);
                    GenerteElems(currElem + 1, chrArray, list);
                    Swap(ref chrArray[currElem], ref chrArray[i]);
                }
            }
        }

        /// <summary>
        /// Find all number combinations.
        /// </summary>
        /// <param name="number">User's number.</param>
        /// <returns>Returns minimal element of all generated elements.</returns>
        private static int FindNumber(int number)
        {
            userNumber = number;
            List<int> list = new List<int>();

            int numLength = number.ToString().Length;
            string numString = number.ToString();
            char[] chrArray = new char[numLength];

            for (int i = 0; i < numLength; i++)
            {
                chrArray[i] = numString[i];
            }

            GenerteElems(0, chrArray, list);

            if (list.Count == 0)
            {
                return -1;
            }

            return list.Min();
        }
    }
}
