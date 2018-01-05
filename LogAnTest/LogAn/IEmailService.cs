using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn
{
    public interface IEmailService
    {
        void SendEmail(EmailInfo emailInfo);
    }
}
