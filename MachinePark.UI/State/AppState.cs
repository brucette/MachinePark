using MachinePark.Core.Models;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace MachinePark.UI.State
{
    public class AppState
    {
        public event Action OnStateChange;

        public void NotifyStateChanged() => OnStateChange?.Invoke();
        

        //public event Action OnStateChange;

        //public void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
