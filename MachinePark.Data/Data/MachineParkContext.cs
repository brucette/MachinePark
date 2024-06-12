using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MachinePark.Data.Domain;
using MachinePark.Core.Domain;

public class MachineParkContext : DbContext
    {
        public MachineParkContext(DbContextOptions<MachineParkContext> options)
            : base(options)
        {
        }

        public DbSet<Machine> Machines { get; set; } = default!;
        public DbSet<ReceivedData> ReceivedData { get; set; } = default!;
    }
