using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorServerSignalRIdentity
{
    public class OurHub : Hub
    {
        public static Dictionary<string, int> currentUser = new Dictionary<string, int>();
        public async Task NotifyEveryoneIn()
        {
            var username = Context.User.Claims.Where(s => s.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            if (currentUser.ContainsKey(username))
            {
                currentUser[username]++;
            }
            else
            {
                currentUser.Add(username, 1);
            }
            await Clients.All.SendAsync("Update");
        }
        public async Task NotifyEveryoneOut()
        {
            var username = Context.User.Claims.Where(s => s.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            if(currentUser.Where(s => s.Key == username).First().Value == 1)
            {
                currentUser.Remove(username);
            }
            await Clients.All.SendAsync("Update");
        }
        public async Task SendSpecific(string userName, string Message)
        {
            var username = Context.User.Claims.Where(s => s.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            await Clients.User(userName).SendAsync("ReceiveMessage", username, Message);
        }
    }
}
