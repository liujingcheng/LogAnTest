using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LogAn
{
    public class LogAnalyzer2
    {
        public IWebService Service { get; set; }
        public IEmailService Email { get; set; }
        public LogAnalyzer2(IWebService service, IEmailService email)
        {
            Service = service;
            Email = email;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    Service.LogError("Filename too short:" + fileName);
                    throw new Exception();
                }
                catch (Exception e)
                {
                    Email.SendEmail(new EmailInfo() { To = "someone@somewhere.com", Subject = "can't log", Body = e.Message });
                }
            }
        }

    }
}
