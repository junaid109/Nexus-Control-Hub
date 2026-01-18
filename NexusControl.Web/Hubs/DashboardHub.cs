using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace NexusControl.Web.Hubs
{
    public class DashboardHub : Hub
    {
        public async Task SendAlert(string message)
        {
            await Clients.All.SendAsync("ReceiveAlert", message);
        }

        public async Task UpdatePlayerCount(int count)
        {
            await Clients.All.SendAsync("UpdatePlayerCount", count);
        }
    }
}

