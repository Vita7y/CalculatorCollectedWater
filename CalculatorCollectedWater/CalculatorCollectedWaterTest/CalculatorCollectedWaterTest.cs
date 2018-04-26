using CalculatorCollectedWater;
using Xunit;

namespace CalculatorCollectedWaterTest
{
    public class CalculatorCollectedWaterTest
    {
        [Fact]
        public void Test_Problem()
        {
            var calculator = new Problem();
            Assert.NotNull(calculator);
        }

        [Fact]
        public void Test_Problem_Empty()
        {
            var calculator = new Problem();
            var res = calculator.Solve(null);
            Assert.Equal(-1, res);
        }

        [Fact]
        public void Test_Problem_SomeValuesOutOfBorder()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new []{1,0, -1, 1});
            Assert.Equal(-1, res);

            res = calculator.Solve(new[] { 1, 32001, 1, 2 });
            Assert.Equal(-1, res);

            var arr = new int[32001];
            arr[0] = 1;
            res = calculator.Solve(arr);
            Assert.Equal(-1, res);
        }

        [Fact]
        public void Test_Problem_NothingCollect()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[]{1});
            Assert.Equal(0, res);
            res = calculator.Solve(new[]{ 1, 1, 1});
            Assert.Equal(0, res);
        }

        [Fact]
        public void Test_Problem_TestCollection()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[]{5,2,3,4,5,4,1,3,1});
            Assert.Equal(8, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionInInverse()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 1, 3, 1, 4, 5, 4, 3, 2, 5 });
            Assert.Equal(8, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionIn3Hills()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 5, 2, 3, 4, 5, 4, 1, 3, 1, 3 });
            Assert.Equal(10, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionIn2Hills()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 5, 2, 3, 4, 5, 4, 1, 3, 1, 4, 1});
            Assert.Equal(13, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionDownHills()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 5, 1, 4, 1, 3, 1, 2 });
            Assert.Equal(6, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionDownUpHills()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 5, 1, 4, 1, 3, 1, 2, 1, 2, 1, 3, 1, 4, 1, 5 });
            Assert.Equal(40, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionDownUpHillsShort()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 5, 1, 4, 1, 3, 1, 2, 1, 2, 1, 3, 1, 4, 1 });
            Assert.Equal(24, res);
        }


        [Fact]
        public void Test_Problem_TestCollectionUpHills()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 2, 1, 3, 1, 4, 1, 5 });
            Assert.Equal(6, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionSameHills()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 2, 1, 2, 1, 2, 1, 2 });
            Assert.Equal(3, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionHillsWithoutHollows()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 1, 2, 3, 4, 5 });
            Assert.Equal(0, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionHillsWithoutHollowsInverse()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 5, 4, 3, 2, 1 });
            Assert.Equal(0, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionMountain()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 });
            Assert.Equal(0, res);
        }

        [Fact]
        public void Test_Problem_TestCollectionMountainInverse()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 5, 4, 3, 2, 1, 2, 3, 4, 5 });
            Assert.Equal(16, res);
        }

        [Fact]
        public void Test_Problem_TestDifferentHillsLivel()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] {6, 5, 4, 6, 6, 5, 4, 3, 5, 1, 2, 3, 1});
            Assert.Equal(9, res);
        }
        [Fact]
        public void Test_Problem_TestDifferentHillsLivelInverse()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 1,3,2,1,5,3,4,5,6,6,4,5,6 });
            Assert.Equal(9, res);
        }

        [Fact]
        public void Test_Problem_Test2()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] {1, 2, 5, 4, 1, 3, 4, 3, 2, 4, 3, 7, 5, 3});
            Assert.Equal(16, res);
        }

        [Fact]
        public void Test_Problem_Test2Inverse()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 3,5,7,3,4,2,3,4,3,1,4,5,2,1 });
            Assert.Equal(16, res);
        }

        [Fact]
        public void Test_Problem_TestFromManagerAnswer()
        {
            var calculator = new Problem();
            var res = calculator.Solve(new[] { 1,2,0,2 });
            Assert.Equal(2, res);
        }

    }
}
