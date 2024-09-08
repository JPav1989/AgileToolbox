using Microsoft.AspNetCore.SignalR;

namespace AgileToolbox.Hubs;

public class PokerHub: Hub
{
    public async Task SendMessage(string user, string estimate)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, estimate);
    }

    public async Task ToggleShow(bool showEstimates)
    {
        await Clients.All.SendAsync("ReceiveShowMessage", showEstimates);
    }

    public async Task ClearEstimates(Dictionary<string, string> estimates)
    {
        await Clients.All.SendAsync("ReceiveClearEstimates", estimates);
    }

    public async Task SyncEstimates(Dictionary<string, string> estimates)
    {
        await Clients.All.SendAsync("ReceiveSyncEstimates", estimates);
    }

    public async Task ToggleVote(bool pokerType)
    {
        await Clients.All.SendAsync("ReceiveToggleVote", pokerType);
    }    
}
