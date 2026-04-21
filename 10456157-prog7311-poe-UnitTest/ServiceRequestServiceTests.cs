using Xunit;
using _10456157_Prog7311_poe.Services;
using _10456157_Prog7311_poe.Models;

namespace _10456157_prog7311_poe_UnitTest
{
    public class ServiceRequestServiceTests
    {
        [Fact]
        public void CanCreate_ReturnsTrue_WhenContractIsActive()
        {
            var service = new ServiceRequestService();

            var contract = new Contract
            {
                Status = "Active"
            };

            var result = service.CanCreate(contract);

            Assert.True(result);
        }

        [Fact]
        public void CanCreate_ReturnsFalse_WhenContractIsNotActive()
        {
            var service = new ServiceRequestService();

            var contract = new Contract
            {
                Status = "Expired"
            };

            var result = service.CanCreate(contract);

            Assert.False(result);
        }
    }
}
