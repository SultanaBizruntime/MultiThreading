using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class AccountManager
    {
        private static log4net.ILog log = log4net.LogManager.
        GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        Account fromAccount;
        Account toAccount;
        double amountToTransfer;

        public AccountManager(Account fromAccount, Account toAccount, double amountToTransfer)
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
                Thread.Sleep(1000);
                lock (toAccount)
                {
                    fromAccount.Withdraw(amountToTransfer);
                    toAccount.Deposit(amountToTransfer);
                }
            }

        }
    }
}
