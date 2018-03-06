using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkProgramming
{
    /// <summary>
    /// ForeGroundThread is a class
    /// </summary>
    class ForeGroundThread
    {
        static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// main method executed
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Thread will be created to run 
            //Function1 parallel
            Thread obj1 = new Thread(Function1);
            obj1.IsBackground = true;
            obj1.Start();

            //the control will come here exit the main function 
            log.Info("The main application has exited");

            Console.ReadLine();

        }
        /// <summary>
        /// Function1 method
        /// </summary>
        static void Function1()
        {
            log.Info("Function1 is entered.....");

            //wait here until put any input
            log.Info("Enter name");
            string a = Console.ReadLine();
            log.Info("user defined data : " + a);
            log.Info("Function1 is exited....");
        }
      
    }
}
