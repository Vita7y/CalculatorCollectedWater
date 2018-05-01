using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CalculatorCollectedWater
{
    public class Problem2
    {
        private Thread _thread;
        private readonly ConcurrentQueue<Tuple<int, int>> _queue = new ConcurrentQueue<Tuple<int, int>>();
        private int[] _heigts;

        private volatile bool _work;
        private volatile int _summ;

        private void Work()
        {
            while (_work)
            {
                while (!_queue.IsEmpty)
                {
                    if (_queue.TryDequeue(out var hollow))
                        _summ += FillHillsWithWater(hollow, _heigts);
                }
            }
            while (!_queue.IsEmpty)
            {
                if (_queue.TryDequeue(out var hollow))
                    _summ += FillHillsWithWater(hollow, _heigts);
            }
        }

        public int Solve(int[] heigts)
        {
            if (!CheckInputData(heigts))
                return -1;
            
            _thread = new Thread(Work);

            _heigts = heigts;
            _work = true;
            _thread.Start();

            CalcHills(heigts);
            _work = false;
            _thread.Join();

            return _summ;
        }

        private static bool CheckInputData(IReadOnlyCollection<int> heigts)
        {
            if (heigts == null || heigts.Count == 0 || heigts.Count > 32000)
                return false;

            return heigts.All(heigt => heigt >= 0 && heigt <= 32000);
        }

        private void CalcHills(IReadOnlyList<int> heigts)
        {
            for (var i = 0; i < heigts.Count - 1; i++)
            {
                var left = heigts[i];
                var tmpRight = heigts[i + 1];
                if (tmpRight >= left)
                    continue;

                var foundEndOfHill = false;
                var tmpEndOfHill = new Tuple<int, int>(0, 0);
                for (var j = i + 1; j < heigts.Count; j++)
                {
                    var right = heigts[j];
                    if (right >= left)
                    {
                        foundEndOfHill = true;
                        _queue.Enqueue(new Tuple<int, int>(i, j));
                        i = j - 1;
                        break;
                    }

                    if (tmpEndOfHill.Item2 < right)
                        tmpEndOfHill = new Tuple<int, int>(j, right);
                }

                if (!foundEndOfHill && tmpEndOfHill.Item1 != 0)
                {
                    _queue.Enqueue(new Tuple<int, int>(i, tmpEndOfHill.Item1));
                    i = tmpEndOfHill.Item1 - 1;
                }
            }
        }

        private static int FillHillsWithWater(Tuple<int, int> hollow, IReadOnlyList<int> heigts)
        {
            var result = 0;
            var left = heigts[hollow.Item1];
            var right = heigts[hollow.Item2];
            var minSide = left > right ? right : left;
            for (var i = hollow.Item1; i < hollow.Item2; i++)
            {
                var delta = minSide - heigts[i];
                if (delta > 0)
                    result += delta;
            }

            return result;
        }
    }
}