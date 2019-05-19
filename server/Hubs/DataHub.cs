using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace server.Hubs
{
    public class DataHub: Hub
    {
        public async Task SendMyEvent()
        {
            var message = "Hello all";
            await Clients.All.SendAsync("HelloEvent", message);
        }
    }
}