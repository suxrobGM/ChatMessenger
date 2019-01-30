using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatCore.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Hubs
{
    public class GroupHub : Hub
    {
        public async void SendMessage(User user, GroupMessage message)
        {
            await Clients.All.SendAsync(message.Text);
        }
    }
}
