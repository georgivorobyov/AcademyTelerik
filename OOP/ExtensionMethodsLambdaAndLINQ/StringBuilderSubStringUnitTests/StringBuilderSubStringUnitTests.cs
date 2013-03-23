using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using StringBuilderSubString;

namespace StringBuilderSubStringUnitTests
{
    [TestClass]
    public class StringBuilderSubStringUnitTests
    {
        [TestMethod]
        public void Index()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Pesho");
            
            var result = builder.SubString(2);

            Assert.AreEqual("sho", result.ToString());
        }

        [TestMethod]
        public void IndexWithLength()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Pesho");
            
            var result = builder.SubString(2, 2);

            Assert.AreEqual("sh", result.ToString());
        }
    }
}
