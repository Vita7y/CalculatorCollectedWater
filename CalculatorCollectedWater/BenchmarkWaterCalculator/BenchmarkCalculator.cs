using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using CalculatorCollectedWater;

namespace BenchmarkWaterCalculator
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    public class BenchmarkCalculator
    {
        private int[] _data;
        readonly Problem _calculator = new Problem();
        readonly Problem2 _calculator2 = new Problem2();

        [Params(100, 1000, 10000, 30000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            var r = new Random();
            _data = new int[N];
            for (var i=0; i< _data.Length; i++)
            {
                _data[i] = r.Next(0, 31999);
            }
        }

        [Benchmark]
        public int CalcWhaterCount() => _calculator.Solve(_data);

        [Benchmark]
        public int CalcWhater2Count() => _calculator2.Solve(_data);

    }
}