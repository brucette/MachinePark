using MachinePark.Core.Models;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace MachinePark.UI.State
{
    public class AppState
    {
        public event Action OnStateChange;

        [Inject]
        public HttpClient Http { get; set; }

        public DashBoardModel Stats { get; set; }

        private string _data;
        public string Data
        {
            get => _data;
            set
            {
                _data = value;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

        private async Task FetchStats()
        {
            Stats = await Http.GetFromJsonAsync<DashBoardModel>("api/machines/stats");
        }
    }
}
