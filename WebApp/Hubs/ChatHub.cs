using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            var userCon = Context.ConnectionId;
            //SendMessage(userCon, "a");
            Connected(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async void SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async void Connected(string userId)
        {
            await Clients.All.SendAsync("CheckConnected", userId);
        }


    }
}
