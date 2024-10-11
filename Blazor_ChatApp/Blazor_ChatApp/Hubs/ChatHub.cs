using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;
using System;
using Ganss.Xss;

namespace BlazorSignalRApp.Hubs
{
    public class ChatHub : Hub

    {
        //Skickar meddelanden till alla anslutna klienter
        public async Task SendMessage(string user, string message, DateTime date)
        {
            var sanitizer = new HtmlSanitizer();
            string sanitizeMessage = sanitizer.Sanitize(message);
            string sanitizeUser = sanitizer.Sanitize(user);

            //Saniterar data för att undvika XSS-attacker

            await Clients.All.SendAsync("ReceiveMessage", sanitizeUser, sanitizeMessage, date);//Skickar det saniterade meddelandet till alla klienter


        }


    }
}
