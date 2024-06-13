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

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<MachineWithLatestData> Machines { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Machines = await Http.GetFromJsonAsync<List<MachineWithLatestData>>("api/machines");
        }

        private void SendData()
        {
            //;
            NavigationManager.NavigateTo("/sendmessage");
        }
        
        private void DeleteMachine()
        {
            //;
        }
        
        private void UpdateMachine()
        {
            //NavigationManager.NavigateTo("/sendmessage");
        }

        private void ChangeStatus()
        {
            //Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }
    }
}
