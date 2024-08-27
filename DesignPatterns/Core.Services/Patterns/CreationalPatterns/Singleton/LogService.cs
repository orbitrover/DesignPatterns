using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.CreationalPatterns.Singleton
{
    public class LogService : ILogService
    {
        private static LogService _instance;
        private static readonly object _lock = new object();
        private LogService() { }

        public static LogService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LogService();
                    }
                    return _instance;
                }
            }
        }

        public void Log(string message)
        {
            // Log to a file, database, etc.
            Console.WriteLine(message);
        }
    }

}
