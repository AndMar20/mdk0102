using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ReyRom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

BenchmarkRunner.Run<Recursion>();

namespace ReyRom
{
    public class Recursion
    {
        [Params(5, 10, 15)]
        public int Fib { get; set; }

        [Benchmark]
        public  int RunFibonacci()
        {
            return Fibonacci(Fib);
        }

        public static int Fibonacci(int n)
        {
            if (n <= 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        [Params(20, 25, 30)]
        public int Fac { get; set; }

        [Benchmark]
        public int RunFactorial()
        {
            return Factorial(Fac);
        }

        public static int Factorial(int n)
        {
            if (n == 1) return 1;
            return n *Factorial(n - 1);
        }
    }
}
