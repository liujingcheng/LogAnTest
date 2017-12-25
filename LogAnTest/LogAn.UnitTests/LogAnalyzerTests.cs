using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [TestCase("filewithgoodextension.SLF", true)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithbadextenson.foo", false)]
        public void IsValidLogFileName_VariousExtensions_ReturnTrue(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, result);
        }

    }
}
