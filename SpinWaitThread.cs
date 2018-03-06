using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkProgramming
{
    /// <summary>
    /// SpinWaitThread is a class
    /// </summary>
    class SpinWaitThread
    {
        /// <summary>
        /// creating log
        /// </summary>
        static  log4net.ILog log = log4net.LogManager.
            GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// SimpleNestedTask is a method
        /// </summary>
        static void SimpleNestedTask()
        {
            
            var parent = Task.Factory.StartNew(() =>
            {
                log.Info("Outer task executing.");

                
                var child = Task.Factory.StartNew(() =>
                {
                   log.Info("Nested task starting.");
                    Thread.SpinWait(500000);
                  log.Info("Nested task completing.");
                });
            });

            parent.Wait();
                log.Info("Outer has completed.");
        }

    }
}
/*Task.Factory.StartNew
 * --------------------------
 
 */
/*gives you the opportunity to define a lot of useful things about the thread you want to create,
...while Task.Run doesn't provide this.*/

/*
 *  A newly created thread that would be dedicated to this task and would be destroyed once your task would have been completed. 
 *  You cannot achieve this with the Task.Run, while you can do so with the Task.Factory.StartNew
 */
