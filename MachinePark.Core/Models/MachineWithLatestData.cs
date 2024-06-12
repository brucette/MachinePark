using MachinePark.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinePark.Core.Models
{
    public class MachineWithLatestData
    {
        public Guid MachineId { get; set; }

        public string Name { get; set; }

        public bool IsOnline { get; set; }

        public string Location { get; set; } = string.Empty;
        public ReceivedData LatestData { get; set; }
    }
}
