using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzer2Tests
    {
        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            FakeWebService stubService = new FakeWebService();
            stubService.ToThrow = new Exception("fake exception");

            FakeEmailService mockEmailService = new FakeEmailService();

            LogAnalyzer2 log = new LogAnalyzer2(stubService, mockEmailService);

            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);

            EmailInfo expectedEmail = new EmailInfo()
            {
                Body = "fake exception",
                To = "someone@somewhere.com",
                Subject = "can't log"
            };

            Assert.AreEqual(expectedEmail, mockEmailService.Email);
        }

    }
}
