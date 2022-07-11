using NUnit.Framework;
using System;
using System.Reflection;

namespace ReflectionTests
{
    public enum ExecutionType
    {
        Native,
        Reflection,
        Lambda,
    }


    public class PerformanceTest
    {
        private const long ONE_MILLION = 1000000;
        private const long ONE_BILLION = 1000000000;
        private const long ONE_TRILLION = 100000000000;
        
        private const long TIMES = ONE_BILLION;

        [Test]
        [TestCase(ExecutionType.Native, TestName = "Native")]
        [TestCase(ExecutionType.Lambda, TestName = "Lambda")]
        [TestCase(ExecutionType.Reflection, TestName = "Reflection")]
        public void All(ExecutionType type)
        {
            DateTime startedAt;
            DateTime finishedAt;
            switch (type)
            {
                case ExecutionType.Native:
                    startedAt = DateTime.Now;
                    for (long i = 0; i < TIMES; i++)
                    {
                        Method();
                    }
                    finishedAt = DateTime.Now;
                    break;
                case ExecutionType.Reflection:
                    MethodInfo m = GetType().GetMethod("Method");
                    var args = new object[] { };

                    startedAt = DateTime.Now;
                    for (long i = 0; i < TIMES; i++)
                    {
                        m.Invoke(this, args);
                    }
                    finishedAt = DateTime.Now;
                    break;
                default:
                    Action action = () =>  Method();

                    startedAt = DateTime.Now;
                    for (long i = 0; i < TIMES; i++)
                    {
                        Run(action);
                    }
                    finishedAt = DateTime.Now;
                    break;
            }

            TimeSpan span = finishedAt - startedAt;
            var time = span.TotalSeconds;
            Console.WriteLine($"Runs {TIMES}");
            Console.WriteLine($"Finished at {time} seconds");
        }

        public void Method()
        {

        }

        private void Run(Action action)
        {
            action.Invoke();
        }
    }
}