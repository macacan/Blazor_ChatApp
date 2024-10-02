using Microsoft.AspNetCore.SignalR;
using System;

namespace BlazorSignalRApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, DateTime date)
        {
            string sanitizedMessage = SanitizeInput(message);

            await Clients.All.SendAsync("ReceiveMessage", user, sanitizedMessage, date);
        }

        private string SanitizeInput(string input)
        {
            return System.Net.WebUtility.HtmlEncode(input); 
        }
    }
}
