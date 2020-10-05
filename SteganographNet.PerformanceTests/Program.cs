using BenchmarkDotNet.Running;

namespace SteganographNet.PerformanceTests
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<ImageRgba32SteganographerBenchmarks>();
        }
    }
}
