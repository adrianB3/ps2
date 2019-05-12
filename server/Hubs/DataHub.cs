using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace server.Hubs
{
    public class DataHub: Hub
    {
        public async Task SendMyEvent()
        {
            await Clients.All.SendAsync("MyEvent");
        }
    }
}