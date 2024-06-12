using MachinePark.Core.Models;
using Microsoft.AspNetCore.Components;

namespace MachinePark.UI.Components
{
    public partial class DashBoard : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        public DashBoardModel Stats { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Stats = await Http.GetFromJsonAsync<DashBoardModel>("api/machines/stats");
        }
    }
}
