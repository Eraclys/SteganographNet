using BenchmarkDotNet.Running;

namespace StenographNet.PerformanceTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ImageRgba32StenographerBenchmarks>();
        }
    }
}
