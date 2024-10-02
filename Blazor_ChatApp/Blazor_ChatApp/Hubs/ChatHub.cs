using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message, DateTime date)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message,date);
    }
}