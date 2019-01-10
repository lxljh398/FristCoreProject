using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TreadTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = null;
            Console.WriteLine($"The first letter of {s} is {s[0]}");

            //Te();
            Console.ReadLine();
        }

        #region Parallel        
        private static void ddd()
        {
            var watch = Stopwatch.StartNew();
            watch.Start();
            Run1();
            Run2();
            Console.WriteLine("我是串行开发，总共耗时:{0}\n", watch.ElapsedMilliseconds);
            watch.Restart();
            try
            {
                Parallel.Invoke(Run1, Run2);
            }
            catch (AggregateException ex)
            {
                foreach (var single in ex.InnerExceptions)
                {
                    Console.WriteLine(single.Message);
                }
            }
            watch.Stop();
            Console.WriteLine("我是并行开发，总共耗时:{0}", watch.ElapsedMilliseconds);
        }

        private static void aaa()
        {
            for (int j = 1; j < 4; j++)
            {
                Console.WriteLine("\n第{0}次比较", j);

                ConcurrentBag<int> bag = new ConcurrentBag<int>();

                var watch = Stopwatch.StartNew();

                //watch.Start();

                //for (int i = 0; i < 20000000; i++)
                //{
                //    bag.Add(i);
                //}

                //Console.WriteLine("串行计算：集合有:{0},总共耗时：{1}", bag.Count, watch.ElapsedMilliseconds);

                //GC.Collect();

                //bag = new ConcurrentBag<int>();

                //watch = Stopwatch.StartNew();

                watch.Start();

                Parallel.For(0, 10, (i, state) =>
                {
                    if (bag.Count == 5)
                    {
                        state.Break();
                        return;
                    }
                    bag.Add(i);
                });

                Console.WriteLine("当前集合有{0}个元素。", bag.Count);

                Console.WriteLine("并行计算：集合有:{0},总共耗时：{1}", bag.Count, watch.ElapsedMilliseconds);

                GC.Collect();

            }
        }

        private static void bbb()
        {
            for (int j = 1; j < 4; j++)
            {
                Console.WriteLine("\n第{0}次比较", j);

                ConcurrentBag<int> bag = new ConcurrentBag<int>();

                var watch = Stopwatch.StartNew();

                watch.Start();

                for (int i = 0; i < 20000000; i++)
                {
                    bag.Add(i);
                }

                Console.WriteLine("串行计算：集合有:{0},总共耗时：{1}", bag.Count, watch.ElapsedMilliseconds);

                GC.Collect();




                bag = new ConcurrentBag<int>();

                watch = Stopwatch.StartNew();

                watch.Start();

                Parallel.For(0, 20000000, i =>
                {
                    bag.Add(i);
                });

                Console.WriteLine("并行计算1：集合有:{0},总共耗时：{1}", bag.Count, watch.ElapsedMilliseconds);

                GC.Collect();




                bag = new ConcurrentBag<int>();

                watch = Stopwatch.StartNew();

                watch.Start();

                Parallel.ForEach(Partitioner.Create(0, 20000000), i =>
                {
                    for (int m = i.Item1; m < i.Item2; m++)
                    {
                        bag.Add(m);
                    }
                });

                Console.WriteLine("并行计算2：集合有:{0},总共耗时：{1}", bag.Count, watch.ElapsedMilliseconds);

                GC.Collect();

            }
        }

        private static void ccc()
        {
            var bag = new ConcurrentBag<int>();

            ParallelOptions options = new ParallelOptions();

            //指定使用的硬件线程数为1
            options.MaxDegreeOfParallelism = 1;

            Parallel.For(0, 300000, options, i =>
            {
                bag.Add(i);
            });

            Console.WriteLine("并行计算：集合有:{0}", bag.Count);
        }
        #endregion

        #region Task
        public static void Ta()
        {
            var a = new Task(() =>
            Run1()
            );
        }
        private static void Tb()
        {
            var b = Task.Factory.StartNew(() => Run1());
        }

        private static void Tc()
        {
            var task1 = new Task(() => Run1());
            var task2 = Task.Factory.StartNew(() => Run2());

            Console.WriteLine("调用start之前****************************\n");
            Console.WriteLine("task1的状态:{0}", task1.Status);
            Console.WriteLine("task2的状态:{0}", task2.Status);
            task1.Start();

            Console.WriteLine("\n调用start之后****************************");
            Console.WriteLine("\ntask1的状态:{0}", task1.Status);
            Console.WriteLine("task2的状态:{0}", task2.Status);

            Task.WaitAll(task1, task2);
            Console.WriteLine("\n任务执行完后的状态****************************");
            Console.WriteLine("\ntask1的状态:{0}", task1.Status);
            Console.WriteLine("task2的状态:{0}", task2.Status);
        }

        static void Td()
        {
            var t1 = Task.Factory.StartNew<List<string>>(() => { return GetVs(); });
            t1.Wait();

            var t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("t1集合中返回的个数：" + string.Join(",", t1.Result));
            }
            );
        }

        static void Te()
        {
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) =>
                {
                    CustomData data = obj as CustomData;
                    if (data == null)
                        return;

                    data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                },
                new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }
            Task.WaitAll(taskArray);
            foreach (var task in taskArray)
            {
                var data = task.AsyncState as CustomData;
                if (data != null)
                    Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.",
                                      data.Name, data.CreationTime, data.ThreadNum);
            }
        }


        class CustomData
        {
            public long CreationTime;
            public int Name;
            public int ThreadNum;
        }

        static List<string> GetVs()
        {
            return new List<string> { "1", "4", "8" };
        }
        #endregion

        static void Run1()
        {
            Console.WriteLine("我是任务一,我跑了1s");
            Thread.Sleep(1000);
        }

        static void Run2()
        {
            Console.WriteLine("我是任务二，我跑了2s");
            Thread.Sleep(2000);
            //throw new Exception("我是任务2抛出的异常");
        }
    }
}
