using MachinePark.Core;
using MachinePark.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace MachinePark.Data.Domain
{
    public class Machine
    {
        public Guid MachineId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Name is too long")]

        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsOnline { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Location name is too long")]
        public string Location { get; set; } = string.Empty;
    }
}
