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
        //public Machine[] Machines { get; set; }
        public List<MachineWithLatestData> Machines { get; set; }

        //public ReceivedData? LastDataReceived { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Machines = await Http.GetFromJsonAsync<Machine[]>("api/machines");
            Machines = await Http.GetFromJsonAsync<List<MachineWithLatestData>>("api/machines");
        }
    }
}
