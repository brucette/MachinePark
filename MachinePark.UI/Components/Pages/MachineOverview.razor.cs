using MachinePark.Core.Domain;
using MachinePark.Core.Models;
using MachinePark.Data.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace MachinePark.UI.Components.Pages
{
    public partial class MachineOverview : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        //[Inject]
        //public NavigationManager NavigationManager { get; set; }

        public List<MachineWithLatestData> Machines { get; set; }

        protected async override Task OnInitializedAsync()
        //protected override async Task OnParametersSetAsync()
        {
            Machines = await Http.GetFromJsonAsync<List<MachineWithLatestData>>("api/machines");
        }

        //private void NavigateToSendMessage(Guid MachineId)
        //{
        //    NavigationManager.NavigateTo($"/sendmessage/{MachineId}");
        //}
        private async Task DeleteMachine(MachineWithLatestData machine)
        {
            var response = await Http.DeleteAsync($"api/machines/{machine.MachineId}");

            if (response.IsSuccessStatusCode)
            {
                await OnInitializedAsync();
            }
        }

        private void UpdateMachine()
        {
            //NavigationManager.NavigateTo("/sendmessage");
        }

        //private void ChangeStatus(MachineWithLatestData machine)
        //{
        //    machine.IsOnline = !machine.IsOnline;
        //}
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
