using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerfulWindSlickedBackHair
{
    public static class Tracker
    {
        public static List<Thread> threads = new List<Thread>();

        public static long frame;

        public static Thread AddThread(string name, ThreadStart start)
        {
            Thread thread = new Thread(start);
            thread.Name = name;
            threads.Add(thread);
            return thread;
        }

        public static void StopAll()
        {
            foreach (Thread thread in threads)
            {
                thread.Abort();
            }
        }
    }
}
