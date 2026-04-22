namespace _10456157_Prog7311_poe.Models
{
    public class Contract
    {
        public int ContractId { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; } 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; }
        public string ServiceLevel { get; set; }

        public string FilePath { get; set; }

        public ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
    }
}