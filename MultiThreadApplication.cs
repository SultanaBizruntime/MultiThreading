using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class MultiThreadApplication
    {
        private static log4net.ILog log = log4net.LogManager.
            GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Thread th = Thread.CurrentThread;
            th.Name = "MainThread";

            log.InfoFormat("This is {0}", th.Name);
            th.Abort();
            
         
        }


    }
}
