using Polly;
using Polly.Timeout;
using System;
using System.Threading;

namespace PollyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Policy policytimeout = Policy.Timeout(3, TimeoutStrategy.Pessimistic);
            Policy policyFallBack = Policy.Handle<TimeoutRejectedException>()
                .Fallback(() =>
                {
                    Console.WriteLine("熔断降级");
                });
            Policy policy = policyFallBack.Wrap(policytimeout);
            policy.Execute(() =>
            {
                Console.WriteLine("完成任务");
                Thread.Sleep(5000);
                Console.WriteLine("完成任务");
            });
            Console.ReadKey();



            Console.ReadLine();
        }
    }
}
