using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorCollectedWater
{
    public class Problem: IProblem
    {
        public int Solve(int[] heigts)
        {
            if(!CheckHeigts(heigts))
                return -1;

            var hollows = CalcHills(heigts);
            return FillHillsOfWater(hollows, heigts);
        }

        private bool CheckHeigts(int[] heigts)
        {
            if (heigts == null || heigts.Length == 0)
                return false;

            return heigts.All(heigt => heigt > 0 && heigt < 32000);
        }

        private List<Tuple<int, int>> CalcHills(int[] heigts)
        {
            var hollows = new List<Tuple<int, int>>();
            for (int i=0; i<heigts.Length-1; i++)
            {
                int left = heigts[i];
                int tmp = heigts[i+1];
                if(tmp >= left)
                    continue;

                var foundEndOfHill = false;
                Tuple<int, int> tmpEndOfHill = new Tuple<int, int>(0,0);
                for (int j = i; j < heigts.Length; j++)
                {
                    var right = heigts[j];
                    if (right >= left)
                    {
                        foundEndOfHill = true;
                        hollows.Add(new Tuple<int, int>(i, j));
                        i = j;
                        break;
                    }

                    if (tmpEndOfHill.Item2 < right)
                        tmpEndOfHill = new Tuple<int, int>(j, right);
                }

                if (!foundEndOfHill && tmpEndOfHill.Item1 != 0)
                {
                    hollows.Add(new Tuple<int, int>(i, tmpEndOfHill.Item1));
                    i = tmpEndOfHill.Item1;
                }
            }

            return hollows;
        }

        private int FillHillsOfWater(List<Tuple<int, int>> hollows, int[] heigts)
        {
            var result = 0;
            foreach (var hollow in hollows)
            {
                var left = heigts[hollow.Item1];
                var right = heigts[hollow.Item2];
                var min = left > right ? right : left;
                for (int i = hollow.Item1; i < hollow.Item2; i++)
                {
                    var delta = min - heigts[i];
                    if (delta > 0)
                        result += delta;
                }
            }
            return result;
        }
    }
}