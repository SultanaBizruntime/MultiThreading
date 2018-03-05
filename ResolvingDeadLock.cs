using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class ResolvingDeadLock
    {
        private static log4net.ILog log = log4net.LogManager.
       GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        Account fromAccount;
        Account toAccount;
        double amountToTransfer;

        public ResolvingDeadLock(Account fromAccount, Account toAccount, double amountToTransfer)
        {
            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
            this.amountToTransfer = amountToTransfer;
        }

        public void Transfer()
        {
            log.Info(Thread.CurrentThread.Name + " trying to acquire lock on" + fromAccount.ID.ToString());
            lock (fromAccount)
            {
                log.Info(Thread.CurrentThread.Name + "acquired lock on" + fromAccount.ID.ToString());
                log.Info(Thread.CurrentThread.Name + "suspended for 1 second");
                Thread.Sleep(1000);
                log.Info(Thread.CurrentThread.Name + "Thread back in action and trying to acquire lock on" + fromAccount.ID.ToString());

                lock (toAccount)
                {
                    log.Info("this code will not be executed");
                    fromAccount.Withdraw(amountToTransfer);
                    toAccount.Deposit(amountToTransfer);
                }
            }

        }
    }
}
