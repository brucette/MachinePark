using MachinePark.Data.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinePark.Core.Domain
{
    public class ReceivedData
    {
        public int ReceivedDataId { get; set; }

        [Required]
        public Guid MachineId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Message is too long")]
        public string Data { get; set; }
    }
}
