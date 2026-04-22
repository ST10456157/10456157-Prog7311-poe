using System.Diagnostics.Contracts;

namespace _10456157_Prog7311_poe.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string ContactDetails { get; set; }
        public string Region { get; set; }

        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
