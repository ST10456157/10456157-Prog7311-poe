using Xunit;
using _10456157_Prog7311_poe.Models;

namespace _10456157_prog7311_poe_UnitTest
{
    public class ContractTests
    {
        [Fact]
        public void Contract_ShouldStoreCorrectValues()
        {
            var contract = new Contract
            {
                Status = "Active",
                ServiceLevel = "Express"
            };

            Assert.Equal("Active", contract.Status);
            Assert.Equal("Express", contract.ServiceLevel);
        }
    }
}
