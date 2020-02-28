using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSamples
{
    class Program
    {
        private static readonly Command[] s_commands =
        {
            new Command("-p1", nameof(TasksUsingThreadPool), TasksUsingThreadPool),
            new Command("-s1", nameof(RunSynchronousTask), RunSynchronousTask),
            new Command("-l1", nameof(LongRunningTask), LongRunningTask),
            new Command("-r1", nameof(TaskWithResultDemo), TaskWithResultDemo),
            new Command("-c1", nameof(ContinuationTasks), ContinuationTasks),
            new Command("-pc1", nameof(ParentAndChild), ParentAndChild),
        };


        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length > 1 || !s_commands.Select(c => c.Option).Contains(args[0]))
            {
                ShowUsage();
                return;
            }

            s_commands.Single(c => c.Option == args[0]).Action();

            Console.ReadLine();
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Usage: TaskSamples [options]");
            Console.WriteLine();
            foreach (var command in s_commands)
            {
                Console.WriteLine($"{command.Option} {command.Text}");
            }
        }

        public static void ParentAndChild()
        {
            var parent = new Task(ParentTask);
            parent.Start();

            var r = Console.ReadLine();
            while(r.ToLower() != "exit"){
                //Task.Delay(2000).Wait();
                Console.WriteLine(parent.Status);
                r = Console.ReadLine();
            }
           


            Console.WriteLine(parent.Status);
        }

        private static void ParentTask()
        {
            Console.WriteLine($"task id {Task.CurrentId}");
            var child = new Task(ChildTask);
            child.Start();
            Task.Delay(1000).Wait();
            Console.WriteLine("parent started child");
        }

        private static void ChildTask()
        {
            Console.WriteLine("child");
            Task.Delay(5000).Wait();
            Console.WriteLine("child finished");
        }

        public static void ContinuationTasks()
        {          
            Task t1 = new Task(DoOnFirst);
            Task t2 = t1.ContinueWith(DoOnSecond);
            Task t3 = t2.ContinueWith(DoOnSecond);
            Task t4 = t3.ContinueWith(DoOnSecond);
            t1.Start();
        }

        private static void DoOnFirst()
        {
            Console.WriteLine($"doing some task {Task.CurrentId}");
            Task.Delay(3000).Wait();
        }

        private static void DoOnSecond(Task t)
        {
            Console.WriteLine($"task {t.Id} finished");
            Console.WriteLine($"this task id {Task.CurrentId}");
            Console.WriteLine("do some cleanup");
            Task.Delay(3000).Wait();
        }

        public static void TaskWithResultDemo()
        {
            var t1 = new Task<(int Result, int Remainder)>(TaskWithResult, (8, 3));
            t1.Start();
            Console.WriteLine(t1.Result);
            t1.Wait();
            Console.WriteLine($"result from task: {t1.Result.Result} {t1.Result.Remainder}");
        }

        private static (int Result, int Remainder) TaskWithResult(object division)
        {
            (int x, int y) = ((int x, int y))division;
            int result = x / y;
            int remainder = x % y;
            Console.WriteLine("task creates a result...");

            return (result, remainder);
        }

        public static void TasksUsingThreadPool()
        {
            var tf = new TaskFactory();
            Task t1 = tf.StartNew(TaskMethod, "using a task factory");
            Task t2 = Task.Factory.StartNew(TaskMethod, "factory via a task");
            var t3 = new Task(TaskMethod, "using a task constructor and Start");
            t3.Start();
            Task t4 = Task.Run(() => TaskMethod("using the Run method"));
        }

        public static void RunSynchronousTask()
        {
            TaskMethod("just the main thread");
            var t1 = new Task(TaskMethod, "run sync");
            t1.RunSynchronously();
        }

        public static void LongRunningTask()
        {
            var t1 = new Task(TaskMethod, "long running",
              TaskCreationOptions.LongRunning);
            t1.Start();
        }

        public static void TaskMethod(object o)
        {
            Log(o?.ToString());
        }

        private static object s_logLock = new object();

        public static void Log(string title)
        {
            lock (s_logLock)
            {
                Console.WriteLine(title);
                Console.WriteLine($"Task id: {Task.CurrentId?.ToString() ?? "no task"}, thread: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"is pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");
                Console.WriteLine($"is background thread: {Thread.CurrentThread.IsBackground}");
                Console.WriteLine();
            }
        }
    }
}
