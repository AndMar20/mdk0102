using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Profiling>();

[MemoryDiagnoser]    
    public class Profiling
{
    [Params(10, 13, 15 ,17, 20, 25, 30)]
    public long N {  get; set; }

    [Benchmark]
    public void RunFib()
    {
        Fib(N);
    }

    static long Fib(long n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return Fib(n - 1) + Fib(n - 2);
    }
}