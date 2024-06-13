using MachinePark.Data.Domain;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Metrics;

namespace MachinePark.UI.Components.Pages
{
    public partial class AddMachine
    {
        [SupplyParameterFromForm]
        public Machine Machine { get; set; }

        public string Message { get; set; } = string.Empty;
        protected bool IsSaved = false;

        [Inject]
        public HttpClient Http { get; set; }

        public List<bool> OnlineStatus { get; set; } = [true, false];

        protected override void OnInitialized()
        {
            Machine ??= new();
        }

        private async Task OnSubmit()
        {
            var response = await Http.PostAsJsonAsync("api/machines", Machine);
            IsSaved = true;
            Message = "Machine added successfully";
        }
    }
}
