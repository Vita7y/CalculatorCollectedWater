﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorCollectedWater
{
    public class Problem
    {
        public int Solve(int[] heigts)
        {
            if (!CheckInputData(heigts))
                return -1;

            var hollows = CalcHills(heigts);
            return FillHillsWithWater(hollows, heigts);
        }

        private static bool CheckInputData(IReadOnlyCollection<int> heigts)
        {
            if (heigts == null || heigts.Count == 0 || heigts.Count > 32000)
                return false;

            return heigts.All(heigt => heigt >= 0 && heigt <= 32000);
        }

        private static IEnumerable<Tuple<int, int>> CalcHills(IReadOnlyList<int> heigts)
        {
            var hollows = new List<Tuple<int, int>>();
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
                        hollows.Add(new Tuple<int, int>(i, j));
                        i = j - 1;
                        break;
                    }

                    if (tmpEndOfHill.Item2 < right)
                        tmpEndOfHill = new Tuple<int, int>(j, right);
                }

                if (!foundEndOfHill && tmpEndOfHill.Item1 != 0)
                {
                    hollows.Add(new Tuple<int, int>(i, tmpEndOfHill.Item1));
                    i = tmpEndOfHill.Item1 - 1;
                }
            }

            return hollows;
        }

        private static int FillHillsWithWater(IEnumerable<Tuple<int, int>> hollows, IReadOnlyList<int> heigts)
        {
            var result = 0;
            foreach (var hollow in hollows)
            {
                var left = heigts[hollow.Item1];
                var right = heigts[hollow.Item2];
                var minSide = left > right ? right : left;
                for (var i = hollow.Item1; i < hollow.Item2; i++)
                {
                    var delta = minSide - heigts[i];
                    if (delta > 0)
                        result += delta;
                }
            }

            return result;
        }
    }
}