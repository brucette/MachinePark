using MachinePark.Core.Domain;
using Microsoft.AspNetCore.Components;

namespace MachinePark.UI.Components.Pages
{
    public partial class SendDataToMachine
    {
        [SupplyParameterFromForm]
        public ReceivedData ReceivedData { get; set; }

        public string Message { get; set; } = string.Empty;
        protected bool IsSaved = false;

        [Inject]
        public HttpClient Http { get; set; }

        protected override void OnInitialized()
        {
            ReceivedData ??= new();
        }
    }
}
