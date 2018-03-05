using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class ThreadJoin
    {
        private static log4net.ILog log = log4net.LogManager.
           GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static void Main()
        {
            log.Info("main started");

            Thread t1 = new Thread(ThreadJoin.Thread1Function);
            t1.Start();

            Thread t2 = new Thread(ThreadJoin.Thread2Function);
            t2.Start();

            t1.Join();
            log.Info("Thread1Function Completed");


            t2.Join();
            log.Info("Thread2Function Completed");

            log.Info("Main Completed");

        }
        public static void Thread1Function()
        {
            Console.WriteLine("Thread1Function started");
        }
        public static void Thread2Function()
        {
            Console.WriteLine("Thread2Function started");
        }

    }
}
