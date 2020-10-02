using BenchmarkDotNet.Running;

namespace StenographNet.PerformanceTests
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<ImageRgba32StenographerBenchmarks>();
        }
    }
}
