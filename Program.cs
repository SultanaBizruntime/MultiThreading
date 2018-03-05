using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thread T1 = new Thread(Number.PrintNumbers);
            // Thread T1 = new Thread(delegate() { Number.PrintNumbers(); });
            Thread T1 = new Thread (()=> Number.PrintNumbers());
            T1.Start();
        }
    }
    class Number
    {
        private static  log4net.ILog log = log4net.LogManager.
            GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                log.Info(i);
            }
        }
    }
}
