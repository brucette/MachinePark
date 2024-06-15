using MachinePark.Core.Domain;
using MachinePark.Core.Models;
using MachinePark.Data.Domain;
using MachinePark.UI.State;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;

namespace MachinePark.UI.Components.Pages
{
    public partial class MachineOverview : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]    
        public NavigationManager NavigationManager { get; set; }

        public List<MachineWithLatestData> Machines { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Machines = await Http.GetFromJsonAsync<List<MachineWithLatestData>>("api/machines");
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            { 
                Machines = await Http.GetFromJsonAsync<List<MachineWithLatestData>>("api/machines");
            }
        }

        private async Task DeleteMachine(MachineWithLatestData machine)
        {
            var response = await Http.DeleteAsync($"api/machines/{machine.MachineId}");

            if (response.IsSuccessStatusCode)
            {
                await OnAfterRenderAsync(false);
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
                await OnAfterRenderAsync(false);
                NavigateToOverview();
            }
        }

        private void NavigateToOverview()
        {
            NavigationManager.NavigateTo($"/");
        }
    }
}
