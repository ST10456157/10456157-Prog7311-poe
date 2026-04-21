using Xunit;
using _10456157_Prog7311_poe.Services;

namespace _10456157_prog7311_poe_UnitTest
{
    public class CostStrategyTests
    {
        [Fact]
        public void StandardStrategy_ReturnsSameCost()
        {
            var strategy = new StandardStrategy();

            var result = strategy.Calculate(100);

            Assert.Equal(100, result);
        }

        [Fact]
        public void ExpressStrategy_IncreasesCost()
        {
            var strategy = new ExpressStrategy();

            var result = strategy.Calculate(100);

            Assert.Equal(150, result);
        }
    }
}
