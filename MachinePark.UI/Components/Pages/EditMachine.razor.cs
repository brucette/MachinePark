using MachinePark.Core.Models;
using MachinePark.Data.Domain;
using Microsoft.AspNetCore.Components;

namespace MachinePark.UI.Components.Pages
{
    public partial class EditMachine : ComponentBase
    {
        [SupplyParameterFromForm]
        public Machine Machine { get; set; } = new();

        [Parameter]
        public string MachineId { get; set; }

        public string Message { get; set; } = string.Empty;
        protected bool IsSaved = false;

        [Inject]
        public HttpClient Http { get; set; }

        public List<bool> OnlineStatus { get; set; } = [true, false];

        protected override async Task OnInitializedAsync()
        {
            Machine = await Http.GetFromJsonAsync<Machine>($"api/machines/{MachineId}");
            Machine?.MachineId.ToString();
        }

        private async Task OnEditSubmit()
        {
            var response = await Http.PutAsJsonAsync($"api/machines/{MachineId}", Machine);

            IsSaved = true;
            Message = "Machine edited successfully";
        }
    }
}
