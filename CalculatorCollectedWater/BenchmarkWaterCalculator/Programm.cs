using System;
using BenchmarkDotNet.Running;
using BenchmarkWaterCalculator;

namespace CalculatorCollectedWaterTest
{
    public class Programm
    {
        static void Main()
        {
            var summary = BenchmarkRunner.Run<BenchmarkCalculator>();
        }
    }
}