using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        

        public class HelloWordWorkflow : IWorkflow
        {
            public string Id => "HelloWord";

            public int Version => 1;

            public void Build(IWorkflowBuilder<object> builder)
            {
                builder.StartWith<HelloWord>()
                    .Then<ActiveWorld>()
                    .Then<GoodbyeWorld>();
            }
        }

        public class HelloWord : StepBody
        {
            public override ExecutionResult Run(IStepExecutionContext context)
            {
                Console.WriteLine("Hello World");

                return ExecutionResult.Next();
            }
        }

        public class ActiveWorld : StepBody
        {
            public override ExecutionResult Run(IStepExecutionContext context)
            {
                Console.WriteLine("I am activing in the World!");

                return ExecutionResult.Next();
            }
        }

        public class GoodbyeWorld : StepBody
        {
            public override ExecutionResult Run(IStepExecutionContext context)
            {
                Console.WriteLine("Goodbye World!");
                return ExecutionResult.Next();
            }
        }
    }
}
