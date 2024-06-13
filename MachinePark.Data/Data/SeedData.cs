using MachinePark.Core.Domain;
using MachinePark.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace MachinePark.Data.Data
{
    public class SeedData
    {
        public static async Task SeedMachineData(MachineParkContext context)
        {
            // check if any machines exist
            if (await context.Machines.AnyAsync()) return;

            List<Machine> machines = new List<Machine>()
            {
                new Machine
                {
                    MachineId = Guid.Parse("e7a22d38-0f96-4b29-b89a-85bda97f9d6e"),
                    Name = "Some Machine",
                    IsOnline = true,
                    Location = "Stockholm",
                },
                new Machine
                {
                    MachineId = Guid.Parse("f1d98e5d-8d4a-4bda-91c2-5c6d9f99b7e2"),
                    Name = "Another Machine",
                    IsOnline = true,
                    Location = "Helsinki"
                },
                new Machine
                {
                    MachineId = Guid.Parse("c3d845f5-6d57-42c2-b8ec-30368b3ae8c4"),
                    Name = "Third Machine",
                    IsOnline = false,
                    Location = "Oslo",
                }
            };

            List<ReceivedData> receivedData = new List<ReceivedData>()
            {
                new ReceivedData
                {
                    MachineId = Guid.Parse("e7a22d38-0f96-4b29-b89a-85bda97f9d6e"),
                    Time = DateTime.Now,
                    Data = "Initializing"
                },
                new ReceivedData
                {
                    MachineId = Guid.Parse("c3d845f5-6d57-42c2-b8ec-30368b3ae8c4"),
                    Time = DateTime.Now,
                    Data = "Measuring"
                }
            };

            await context.Machines.AddRangeAsync(machines);
            await context.ReceivedData.AddRangeAsync(receivedData);
            await context.SaveChangesAsync();
        }
    }
}
