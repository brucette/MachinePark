﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinePark.Core.Models
{
    public class DashBoardModel
    {
        public int TotalCount { get; set; }

        public int MachinesOnline { get; set; }

        public int Locations { get; set; }

        public Guid LastEditedMachineId { get; set; }
        
        public string LastEditedMachineName { get; set; }
    }
}
