using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class MultiThread1
    {
        static void Main(string[] args)
        {
            // Thread T1 = new Thread(Number.PrintNumbers);
            // Thread T1 = new Thread(delegate() { Number.PrintNumbers(); });
            Number1 num = new Number1();
            Thread T1 = new Thread (num.PrintNumbers);
             T1.Start();

            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(num.PrintNumbers1);
            Thread t2 = new Thread(parameterizedThreadStart);
            t2.Start();
        }

    }

    class Number1
    {
        private static log4net.ILog log = log4net.LogManager.
            GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public  void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                log.Info(i);
            }
        }

        public void PrintNumbers1(object target)
        {
            for (int i = 1; i <= target; i++)
            {
                log.Info(i);
            }
        }

    }

}
