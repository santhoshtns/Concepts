using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConceptTests
{
    public class TasksAsyncTest
    {
        public async void TestAsync()
        {
            Console.WriteLine($"TestAsync: {Thread.CurrentThread.ManagedThreadId}");
            NoReturnTask();
            await NoReturnTask();

        }

        private async Task NoReturnTask()
        {
            Console.WriteLine($"NoReturnTask: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
