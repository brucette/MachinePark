using MachinePark.Core;
using MachinePark.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace MachinePark.Data.Domain
{
    public class Machine
    {
        public Guid MachineId { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsOnline { get; set; }

        [Display(Name = "City")]
        public string Location { get; set; } = string.Empty;

        //public DateTime? LastUpdated { get; set; }
        //public string? LatestReceivedData{ get; set; }

        //public List<ReceivedData> AllReceivedData { get; set; } = new List<ReceivedData>(); 
    }
}
