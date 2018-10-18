using System;
using NUnit.Framework;

namespace FindRoot.Tests
{
    [TestFixture]
    public class RootFinderNTests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRootmethod_UserVariants_CorrectResults(double number, int n, double eps, double result)
        {
            Assert.AreEqual(result, RootFinder.FindNthRoot(number, n, eps), 0.1); 
        }

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindNthRootmethod_UncorrectData_ArgumentException(double number, int n, double eps)
        {
            Assert.Throws<ArgumentException>(() => RootFinder.FindNthRoot(number, n, eps));
        }
    }
}
