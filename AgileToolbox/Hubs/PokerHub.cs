using Microsoft.AspNetCore.SignalR;

namespace AgileToolbox.Hubs;

public class PokerHub: Hub
{
    public async Task SendMessage(string user, string estimate)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, estimate);
    }
}
