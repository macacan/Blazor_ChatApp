using Microsoft.AspNetCore.SignalR;
using System;

namespace BlazorSignalRApp.Hubs
{
    public class ChatHub : Hub

    {
        //Skickar meddelanden till alla anslutna klienter
        public async Task SendMessage(string user, string message, DateTime date)
        {
            string sanitizedMessage = SanitizeInput(message);//Saniterar data för att undvika XSS-attacker

            await Clients.All.SendAsync("ReceiveMessage", user, sanitizedMessage, date);//Skickar det saniterade meddelandet till alla klienter
        }


        //Saniterar meddelanden för att förhindra skadlig kod (XSS)
        private string SanitizeInput(string input)
        {
            return System.Net.WebUtility.HtmlEncode(input); 
        }
    }
}
