using MachinePark.Core.Domain;
using Microsoft.AspNetCore.Components;

namespace MachinePark.UI.Components.Pages
{
    public partial class SendDataToMachine
    {
        [Parameter]
        public string MachineId { get; set; }   

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

        private async Task OnMessageSubmit()
        {
            ReceivedData.MachineId = Guid.Parse(MachineId);
            ReceivedData.Time = DateTime.Now;

            await Http.PostAsJsonAsync("api/receiveddata", ReceivedData);
            IsSaved = true;
            Message = "Message sent successfully";
        }
    }
}
