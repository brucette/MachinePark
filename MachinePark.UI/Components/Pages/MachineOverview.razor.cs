﻿using MachinePark.Core.Domain;
using MachinePark.Core.Models;
using MachinePark.Data.Domain;
using MachinePark.UI.State;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace MachinePark.UI.Components.Pages
{
    public partial class MachineOverview : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        public List<MachineWithLatestData> Machines { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Machines = await Http.GetFromJsonAsync<List<MachineWithLatestData>>("api/machines");
        }

        private async Task DeleteMachine(MachineWithLatestData machine)
        {
            var response = await Http.DeleteAsync($"api/machines/{machine.MachineId}");

            if (response.IsSuccessStatusCode)
            {
                await OnInitializedAsync();
            }
        }

        private async Task ChangeStatus(MachineWithLatestData machine)
        {
            var changedMachine = new Machine
            {
                MachineId = machine.MachineId,
                Name = machine.Name,
                IsOnline = !machine.IsOnline,
                Location = machine.Location
            };
            
            var response = await Http.PutAsJsonAsync($"api/machines/{machine.MachineId}", changedMachine);
            if (response.IsSuccessStatusCode)
            {
                await OnInitializedAsync();
            }
        }
    }
}
