using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    //Pass data to the Thread Function.

    public delegate void SumOfNumbersCallBack(int SumOfNumbers);

    class Multi_Thread2
    {
        private static log4net.ILog log = log4net.LogManager.
           GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void PrintSum(int sum)
        {
            Console.WriteLine("Sum of numbers = " + sum);
        }


        public static void Main()
        {
            log.Info("please enter the target number");
            int target = Convert.ToInt32(Console.ReadLine());

            SumOfNumbersCallBack callback = new SumOfNumbersCallBack(PrintSum);

            Number2 num = new Number2(target);

            Number2 num1 = new Number2(target, callback);

            Thread t1 = new Thread(num.PrintSumOfNumbers);
            t1.Start();

            Thread t2 = new Thread(num1.PrintSumOfNumbers);
            t2.Start();

        }
    }

    class Number2
    {
        private static log4net.ILog log = log4net.LogManager.
            GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int target1;
        SumOfNumbersCallBack _callBackMethod;

        public Number2(int target)
        {
            this.target1 = target;
        }

        public Number2(int target, SumOfNumbersCallBack callBackMethod)
        {
            this._callBackMethod = callBackMethod;
        }


        public void PrintSumOfNumbers()
        {
            int sum = 0;
            for (int i = 1; i <= target1; i++)
            {
                sum = sum + i;

            }
            if (_callBackMethod != null)
                _callBackMethod(sum);

        }

    }

}
