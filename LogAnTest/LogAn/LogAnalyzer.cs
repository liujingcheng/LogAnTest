using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn
{
    public class LogAnalyzer
    {
        private IWebService _service;
        public LogAnalyzer(IWebService service)
        {
            this._service = service;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                _service.LogError("Filename too short:" + fileName);
                }
                catch (Exception e)
                {
                }
            }
        }


        public LogAnalyzer() { }
        public bool WasLastFileNameValid { get; set; }
        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("filename has to be provided");
            }
            if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            WasLastFileNameValid = true;
            return true;
        }



    }
}
