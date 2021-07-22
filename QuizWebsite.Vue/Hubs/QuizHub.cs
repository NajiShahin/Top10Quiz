using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using QuizWebsite.Core.Dtos;
using Newtonsoft.Json;

namespace QuizWebsite.Vue.Hubs
{
    public class QuizHub : Hub
    {
        public async Task AddToGroup()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetAsync("https://localhost:5001/api/Rooms/Join");
            var data = await result.Content.ReadAsStringAsync();
            var group = JsonConvert.DeserializeObject<RoomResponseDto>(data);
            await Groups.AddToGroupAsync(Context.ConnectionId, group.Name);
            var a = Clients.Group(group.Name);
        }

        public override Task OnDisconnectedAsync(Exception a)
        {
            
            return Task.FromResult(true);
        }

        public async Task Send(string message)
        {
            /*
            HttpClient httpClient = new HttpClient();
            // Call the broadcastMessage method to update clients.
            var result = await httpClient.GetAsync("https://localhost:5001/api/Questions");
            var data = await result.Content.ReadAsStringAsync();
            var a = JsonConvert.DeserializeObject<IEnumerable<QuestionResponseDto>>(data) ;
            var c = Clients;
            await Groups.AddToGroupAsync(Context.ConnectionId, "link");
            foreach (var item in a)
            {
                await Clients.All.SendAsync("broadcastMessage", item.QuestionText);
            }
            await Clients.All.SendAsync("broadcastMessage", data);
            */

            await Clients.All.SendAsync("broadcastMessage", message);

        }
    }
}
