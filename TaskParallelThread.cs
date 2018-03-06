using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkProgramming
{
    /// <summary>
    /// TaskParallelThread is a class
    /// </summary>
    class TaskParallelThread
    {
        /// <summary>
        /// creating log
        /// </summary>
        static  log4net.ILog log = log4net.LogManager.
            GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ParallelForEach() is a method
        /// </summary>
        public static void ParallelForEach()
        {
            string[] colors = { "1. Mon", "2.Tue", "3.Wed", "4.Thru" };
            log.Info("Using Parallel Foreach loop");
            Stopwatch s = Stopwatch.StartNew();
            Parallel.ForEach(colors, color =>
            {
                log.InfoFormat("{0}, Thread Id={1}", color, Thread.CurrentThread.ManagedThreadId);
                //ManagedThreadId gets the unique identifier for the current thread
                Thread.Sleep(100);
            });
            log.InfoFormat("Parallel.ForEach() execution time={0} seconds", s.Elapsed.TotalSeconds);
            log.Info("Using Traditional forEach Loop");
            Stopwatch s1 = Stopwatch.StartNew();

            //using foreach  method
            foreach (string color in colors)
            {
                log.InfoFormat("{0}, Thread Id={1}", color, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(200);
            }
            log.InfoFormat("foreach loop execution time ={0} seconds\n", s1.Elapsed.TotalSeconds);
        }

        /// <summary>
        /// main method executed
        /// </summary>
        static void Main()
        {
            TaskParallelThread.ParallelForEach();
            log.Info("Done SuccessFully");

        }
    }
}
