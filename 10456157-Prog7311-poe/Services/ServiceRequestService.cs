using _10456157_Prog7311_poe.Models;
namespace _10456157_Prog7311_poe.Services
{
    public class ServiceRequestService
    {
        public bool CanCreate(Contract contract)
        {
            return contract != null && contract.Status == "Active";
        }
    }
}
