using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming
{
    /// <summary>
    /// NestedLock is a class
    /// </summary>
    class NestedLock
    {
        /// <summary>
        /// creating log
        /// </summary>
        static  log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// x is an instance of object class, static modifier
        /// </summary>
        static object x = new object();

        /// <summary>
        /// AnotherMethod is a method
        /// </summary>
        static void AnotherMethod()
        {
            lock (x)
            {
                log.Info("Another method");
            }
        }

        /// <summary>
        /// Mainmethod executed
        /// </summary>
        static void Main()
        {
            lock (x)
            {
                AnotherMethod();
                // We still have the lock - because locks are reentrant.
                //reentrant : executed more than once at a time either by different threads,or bcz of recursion
            }
           // Console.Read();
        }
    }
}
