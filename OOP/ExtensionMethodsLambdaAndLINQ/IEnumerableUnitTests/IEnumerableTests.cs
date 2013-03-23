using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IEnumerableExtensions;

namespace IEnumerableUnitTests
{
    [TestClass]
    public class IEnumerableTests
    {
        [TestMethod]
        public void MaxInt()
        {
            IEnumerable<int> integers = new int[] { 1, 2, 3, 2, 0 };
            int max = integers.Max();

            Assert.AreEqual(3, max);
        }

        [TestMethod]
        public void MinInt()
        {
            IEnumerable<int> integers = new int[] { 1, 2, 3, 2, 0 };
            int min = integers.Min();

            Assert.AreEqual(0, min);
        }

        [TestMethod]
        public void MaxString()
        {
            IEnumerable<string> strings = new string[] { "a", "b", "z", "c" };
            string max = strings.Max();

            Assert.AreEqual("z", max);
        }

        [TestMethod]
        public void MinString()
        {
            IEnumerable<string> strings = new string[] { "a", "b", "z", "c" };
            string min = strings.Min();

            Assert.AreEqual("a", min);
        }

        [TestMethod]
        public void Count()
        {
            IEnumerable<string> strings = new string[] { "a", "b", "z", "c" };
            int count = strings.Count();

            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void CountWithZeroElementsReferenceType()
        {
            IEnumerable<string> strings = new string[0];
            int count = strings.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void CountWithZeroElementsValueType()
        {
            IEnumerable<int> strings = new int[0];
            int count = strings.Count();

            Assert.AreEqual(0, count);
        }
        
        [TestMethod]
        public void SumWithValueType()
        {
            IEnumerable<int> integers = new int[] { 1, 2, 3 };
            int sum = integers.Sum();

            Assert.AreEqual(6, sum);
        }

        [TestMethod]
        public void SumWithStrings()
        {
            IEnumerable<string> strings = new string[] { "a", "b", "c" };
            string sum = strings.Sum();

            Assert.AreEqual("abc", sum);
        }

        [TestMethod]
        public void Product()
        {
            IEnumerable<int> integers = new int[] { 1, 2, 3 };
            int product = integers.Product();

            Assert.AreEqual(6, product);
        }

        [TestMethod]
        public void Average()
        {
            IEnumerable<int> integers = new int[] { 1, 2, 3 };
            decimal average = integers.Average();

            Assert.AreEqual(2m, average);
        }
    }
}
