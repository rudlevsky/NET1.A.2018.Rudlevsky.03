using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindRoot.Tests
{
    [TestClass]
    public class RootFinderTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Variants.csv",
        "Variants#csv", DataAccessMethod.Sequential), DeploymentItem("Variants.csv")]
        public void GetNthRoot_Test()
        {
            double number = double.Parse(TestContext.DataRow["Number"].ToString());
            int power = int.Parse(TestContext.DataRow["N"].ToString());
            double eps = double.Parse(TestContext.DataRow["Eps"].ToString());
            double expected = double.Parse(TestContext.DataRow["Result"].ToString());
            double actual = RootFinder.FindNthRoot(number, power, eps);
            Assert.AreEqual(actual, expected, eps);
        }

        [TestMethod]
        [DataRow(-0.01, 2, 0.0001)]
        [DataRow(0.001, -2, 0.0001)]
        [DataRow(0.01, 2, -1)]
        public void FindNthRootmethod_UncorrectData_ArgumentException(double number, int n, double eps)
        {
            Assert.ThrowsException<ArgumentException>(() => RootFinder.FindNthRoot(number, n, eps));
        }
    }
}
