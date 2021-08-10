using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using QuizWebsite.Core.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace QuizWebsite.Vue.Hubs
{
    public class QuizHub : Hub
    {
        public async Task<string> AddToGroup(string username)
        {
            HttpClient httpClient = new HttpClient();
            var player = new PlayerRequestDto()
            {
                ConnectionId = this.Context.ConnectionId,
                Name = username,
                Score = 0
            };
            var content = new StringContent(JsonConvert.SerializeObject(player), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("https://localhost:5001/api/player", content);
            var result = await httpClient.GetAsync("https://localhost:5001/api/Rooms/Join/" + this.Context.ConnectionId);
            var data = await result.Content.ReadAsStringAsync();
            var groupDto = JsonConvert.DeserializeObject<RoomResponseDto>(data);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupDto.Name);
            var group = Clients.Group(groupDto.Name);
            await Clients.Group(groupDto.Name).SendAsync("refresh");
            return groupDto.Name;
        }

        public string GetConnectionId()
        {
            return this.Context.ConnectionId;
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            HttpClient httpClient = new HttpClient();

            var result = await httpClient.GetAsync("https://localhost:5001/api/Rooms/Leave/" + this.Context.ConnectionId);
            var response = await result.Content.ReadAsStringAsync();
            var room = JsonConvert.DeserializeObject<RoomResponseDto>(response);
            if (room?.Players.Count == 1)
            {
                await httpClient.DeleteAsync("https://localhost:5001/api/Rooms/" + room.Id);
            }
            await Clients.Group(room?.Name)?.SendAsync("refresh");
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("broadcastMessage", message);
        }
    }
}
