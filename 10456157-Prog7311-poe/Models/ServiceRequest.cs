namespace _10456157_Prog7311_poe.Models
{
    public class ServiceRequest
    {
        public int ServiceRequestId { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }

        public string Description { get; set; }
        public double Cost { get; set; }
        public string Status { get; set; }
    }
}
