﻿using MachinePark.Core.Models;
using MachinePark.UI.State;
using Microsoft.AspNetCore.Components;

namespace MachinePark.UI.Components
{
    public partial class DashBoard : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public AppState AppState { get; set; }

        public DashBoardModel Stats { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await FetchStats();
        }

        private async Task FetchStats()
        { 
            Stats = await Http.GetFromJsonAsync<DashBoardModel>("api/machines/stats");
        }

        //protected override void OnInitialized()
        //{
        //    StatsService.OnStatsUpdated += HandleStatsUpdated;
        //}

        public void Dispose()
        {
            AppState.OnStateChange -= HandleStatsUpdated;
        }

        private void HandleStatsUpdated()
        {
            StateHasChanged(); // Trigger re-rendering of the component
        }
    }
}
