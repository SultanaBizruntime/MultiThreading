using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkProgramming
{
    /// <summary>
    /// MethodOfThreads is a class
    /// </summary>
    class MethodOfThreads
    {
        /// <summary>
        /// sealed class ManualResetEvent : EventWaitHandle
        ///  ManualResetEvent process help us to achieve synchronisation using signal methodology.
        /// ManualResetEvent maintains a boolean variable in memory. When the boolean variable is false
        /// ...then it blocks all threads and when the boolean variable is true it unblocks all threads. 
        ///  if onw WaitOne() is called by the Set(), all the waitOne() will awake, no need of calling again and again.
        /// </summary>
        ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        Thread _thread;

        public MethodOfThreads() { }

        /// <summary>
        /// Start method to start the thread.
        /// </summary>
        public void Start()
        {
            _thread = new Thread(DoWork);
            _thread.Start();
            Console.WriteLine("Thread started running");
        }
        /// <summary>
        /// Pause method to pause the thread.
        /// </summary>
        public void Pause()
        {
            _pauseEvent.Reset();
            Console.WriteLine("Thread paused");
        }

        /// <summary>
        /// Resume() to continue the thread from the paused portion.
        /// </summary>
        public void Resume()
        {
            _pauseEvent.Set();
            Console.WriteLine("Thread resuming ");
        }


        /// <summary>
        /// stop() to stop the thread
        /// </summary>
        public void Stop()
        {
            // Signal the shutdown event
            _shutdownEvent.Set();
            Console.WriteLine("Thread Stopped ");

            // Make sure to resume any paused threads
            _pauseEvent.Set();

            // Wait for the thread to exit
            _thread.Join();
        }

        /// <summary>
        ///  DoWork() is a method
        /// </summary>
        public void DoWork()
        {
            while (true)
            {
                _pauseEvent.WaitOne(Timeout.Infinite);

                if (_shutdownEvent.WaitOne(0))
                    break;
                
                // Do the work..
                Console.WriteLine("Thread is running");

            }

        }
    }
}