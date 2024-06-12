using MachinePark.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinePark.Core.Domain
{
    public class ReceivedData
    {
        public int ReceivedDataId { get; set; }

        public Guid MachineId { get; set; }

        public DateTime Time { get; set; }

        public string Data { get; set; }

        public Machine Machine { get; set; }
    }
}
