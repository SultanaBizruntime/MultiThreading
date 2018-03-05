using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    class SingleThreaded
    {
        private static log4net.ILog log = log4net.LogManager.
          GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static int Total = 0;
        public static void Main()
        {
            AddOn();
            AddOn();
            AddOn();
            log.Info("tOTAL =" + Total);
        }

        public static void AddOn()
        {
            for (int i = 1; i <= 10; i++)
            {
                Total++;
            }
        }
    }    
}
