using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn
{
    public interface ILogger
    {
        void LogError(string message);
    }
}
