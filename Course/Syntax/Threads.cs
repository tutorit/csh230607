using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal class Threads
    {
        static volatile bool bContinue = true;

        static int Calculate(int a, int b)
        {
            Thread.Sleep(2000);
            return a + b;
        }

        async static Task<int> CalculateAsync(int a, int b)
        {
            Task<int> ti = Task.Run(() => Calculate(a, b));
            int ret = await ti;
            return ret;
        }

        async static void AsyncTester()
        {
            Console.WriteLine("Current " + Thread.CurrentThread.GetHashCode());
            int ret = await CalculateAsync(6, 3);
            Console.WriteLine("Async ret: " + ret+", Thread "+Thread.CurrentThread.GetHashCode());
        }

        static void ThreadFunc()
        {
            for(int i = 0; i < 100 && bContinue; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine("Thread " + i+", "+Thread.CurrentThread.GetHashCode());
            }
        }

        public static void ThreadMain()
        {
            AsyncTester();

            Task<int> ti = Task.Run(() => Calculate(5, 6));
            Console.WriteLine("Go on");
            Console.WriteLine("Result " + ti.Result);
            Console.ReadLine();
        }

        public static void xThreadMain()
        {
            Thread t = new Thread(ThreadFunc);
            t.IsBackground = true;
            t.Start();
            Task t2 = new Task(ThreadFunc);
            t2.Start();
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(30);
                Console.WriteLine("Main " + i+", "+Thread.CurrentThread.GetHashCode());
            }
            bContinue = false;
            t.Join();
        }
    }
}
