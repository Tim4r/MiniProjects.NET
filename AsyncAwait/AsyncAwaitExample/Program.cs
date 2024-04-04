using System.Diagnostics;

namespace AsyncAwaitExample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("---------------------");

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            await Wait3000Async();
            HelloWorld();
            await Wait2000Async();
            await Wait1000Async();

            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds);

            async Task Wait3000Async()
            {
                await Task.Delay(3000);
                Console.WriteLine("------ 3000 ------");
            }

            async Task Wait2000Async()
            {
                await Task.Delay(2000);
                Console.WriteLine("------ 2000 ------");
            }

            async Task Wait1000Async()
            {
                await Task.Delay(1000);
                Console.WriteLine("------ 1000 ------");
            }

            void HelloWorld()
            {
                Console.WriteLine("Hi, this is Timur!");
            }


            //Console.WriteLine("---------------------");

            //var stopWatch = new Stopwatch();

            //stopWatch.Start();

            //var task3 = Wait3000Async();
            //var task2 = Wait2000Async();
            //var task1 = Wait1000Async();

            //await task3;
            //HelloWorld();
            //await task2;
            //await task1;

            //stopWatch.Stop();

            //Console.WriteLine(stopWatch.ElapsedMilliseconds);

            //async Task Wait3000Async()
            //{
            //    await Task.Delay(3000);
            //    Console.WriteLine("------ 3000 ------");
            //}

            //async Task Wait2000Async()
            //{
            //    await Task.Delay(2000);
            //    Console.WriteLine("------ 2000 ------");
            //}

            //async Task Wait1000Async()
            //{
            //    await Task.Delay(1000);
            //    Console.WriteLine("------ 1000 ------");
            //}

            //void HelloWorld()
            //{
            //    Console.WriteLine("Hi, this is Timur!");
            //}
        }
    }
}