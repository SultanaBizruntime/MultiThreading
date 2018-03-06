using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkProgramming
{
    /// <summary>
    /// AutoRestEvent is a class
    /// </summary>
    class AutoRestEvent
    {
        static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        ///  sealed class AutoResetEvent : EventWaitHandle
        ///  AutoResetEvent process help us to achieve synchronisation using signal methodology.
        ///  every waitOne() has to called  by Set().
        /// </summary>
        static AutoResetEvent objAuto = new AutoResetEvent(false);

        /// <summary>
        /// sealed class ManualResetEvent : EventWaitHandle
        ///  ManualResetEvent process help us to achieve synchronisation using signal methodology.
        ///  if onw WaitOne() is called by the Set(), all the waitOne() will awake, no need of calling again and again.
        /// </summary>
        static ManualResetEvent objAuto1 = new ManualResetEvent(false);


        /// <summary>
        /// Main method executed
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            new Thread(SomeMethod).Start(); //it will invoke someMethod
            Console.ReadLine();
            //signaled to start again for AutoResetEvent
            objAuto.Set(); //waitOne at 1


            Console.ReadLine();
            //signaled to start again for AutoResetEvent
            objAuto.Set(); //waitOne at 2

            Console.ReadLine();
            //signaled to start again for ManualResetEvent
            objAuto1.Set(); //waitOne at 1

            Console.ReadLine();
            //signaled to start again for ManualResetEvent
            objAuto1.Set(); //waitOne at 2

        }
        /// <summary>
        /// SomeMethod is a method
        /// </summary>
        static void SomeMethod()
        {
            log.Info("starting 1.....");
            //wait
            objAuto.WaitOne();
            log.Info("Finishing 1");

            log.Info("starting 2.....");
            //wait
            objAuto.WaitOne();
            log.Info("Finishing 2.........");

            log.Info("starting 1..for ManualResetEvent...");
            //wait
            objAuto1.WaitOne();
            log.Info("Finishing 1 for ManualResetEvent");

            log.Info("starting 2.. for ManualResetEvent...");
            //wait
            objAuto1.WaitOne();
            log.Info("Finishing 2.. for ManualResetEvent.......");

        }
    }
}
//AutoResetEvent process help us to achieve synchronisation using signal methodology.
