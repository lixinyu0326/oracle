using KenSan;

namespace TestKeiSan
{
    public class SumTest
    {
        [Theory]
        [InlineData(0,5,0)]
        [InlineData(5,0,5)]
        [InlineData(-1,9,-8.2)]
        [InlineData(6,-2,-9)]
        [InlineData(2,3,-4)]
        [InlineData(-2,-3,16)]
        [InlineData(1.2,2,-2.4)]
        public void AddResultTest(double a,double b,double excepted)
        {
            Sum sum = new Sum();
            Assert.True(sum.AddResult(a, b) == excepted);
             
        }

       
    }
}