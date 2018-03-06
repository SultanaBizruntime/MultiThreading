using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkProgramming
{
    /// <summary>
    /// MutexThread is a Class
    /// </summary>
    class MutexThread
    {
       
        static Maths objMaths = new Maths();

        /// <summary>
        /// Main method executed
        /// </summary>
        public static void Main()
        {
            Thread t1 = new Thread(objMaths.Divide);
            t1.Start(); //Child thread
            objMaths.Divide();
        }
    }
    /// <summary>
    /// Maths is a class
    /// </summary>
    class Maths
    {
        /// <summary>
        /// creating log
        /// </summary>
        static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Num1 field
        /// </summary>
        public int Num1;

        /// <summary>
        /// Num2 field
        /// </summary>
        public int Num2;
        
        /// <summary>
        /// Random is a class
        /// </summary>
        Random o = new Random();

        /// <summary>
        /// Divide is a method
        /// </summary>
        public void Divide()
        {
            for (long i = 0; i < 100; i++)
            {
                
                lock (this)
                {
                    Num1 = o.Next(1, 2);
                    Num2 = o.Next(1, 2);
                    int res = Num1 / Num2;
                    Num1 = 0;// to zero
                    Num2 = 0; //Child Thread
                   
                }
                log.Info("Mutex Program");
            }
        }
       
    }
}
