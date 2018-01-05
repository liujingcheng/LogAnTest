using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.UnitTests
{
    public class FakeEmailService:IEmailService
    {
        public EmailInfo Email = null;
        public void SendEmail(EmailInfo emailInfo)
        {
            Email = emailInfo;
        }
    }
}
