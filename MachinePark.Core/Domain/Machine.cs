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

        public string Location { get; set; } = string.Empty;
    }
}
