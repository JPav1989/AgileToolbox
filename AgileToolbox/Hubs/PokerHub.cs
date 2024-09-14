using Microsoft.AspNetCore.SignalR;

namespace AgileToolbox.Hubs;

public class PokerHub: Hub
{
    public async Task JoinRoom(string roomName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        await Clients.Group(roomName).SendAsync("ReceiveJoinRoom", $"{Context.ConnectionId} has entered the room - {roomName}");
    }

    public async Task LeaveRoom(string roomName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        await Clients.Group(roomName).SendAsync("ReceiveLeaveRoom", $"{Context.ConnectionId} has left the room - {roomName}");
    }

    public async Task SendMessage(string roomName, string user, string estimate)
    {
        await Clients.Group(roomName).SendAsync("ReceiveMessage", user, estimate);
    }

    public async Task ToggleShow(string roomName, bool showEstimates)
    {
        await Clients.Group(roomName).SendAsync("ReceiveShowMessage", showEstimates);
    }

    public async Task ClearEstimates(string roomName, Dictionary<string, string> estimates)
    {
        await Clients.Group(roomName).SendAsync("ReceiveClearEstimates", estimates);
    }

    public async Task SyncEstimates(string roomName, Dictionary<string, string> estimates)
    {
        await Clients.Group(roomName).SendAsync("ReceiveSyncEstimates", estimates);
    }

    public async Task ToggleVote(string roomName, bool pokerType)
    {
        await Clients.Group(roomName).SendAsync("ReceiveToggleVote", pokerType);
    }    
}
