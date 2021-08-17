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
using System.Collections.Concurrent;
using System.Diagnostics;

namespace QuizWebsite.Vue.Hubs
{
    public class QuizHub : Hub
    {
        private readonly IHubContext<QuizHub> _hubContext;
        private Random rnd = new Random();
        private static readonly System.Timers.Timer _timer = new System.Timers.Timer();
        public static ConcurrentDictionary<string, List<string>> ConnectedUsers = new ConcurrentDictionary<string, List<string>>();

        public QuizHub(IHubContext<QuizHub> hubContext)
        {
            _hubContext = hubContext;
            _timer.Interval = 1000;
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int month = rnd.Next(1, 1000000);

            /*var result = await httpClient.GetAsync("https://localhost:5001/api/Rooms" + this.Context.ConnectionId);
            var data = await result.Content.ReadAsStringAsync();
            var player = JsonConvert.DeserializeObject<PlayerResponseDto>(data);*/

            _hubContext.Clients.All.SendAsync("blob", month);
        }



        public async Task answer(int place, string answer, string color)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetAsync("https://localhost:5001/api/Player?connectionId=" + this.Context.ConnectionId);
            var data = await result.Content.ReadAsStringAsync();
            var player = JsonConvert.DeserializeObject<PlayerResponseDto>(data);
            await Clients.Group(player.Room.Name).SendAsync("showAnswer", place, answer, color);
        }

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
            await Clients.Group(groupDto.Name).SendAsync("userJoined");
            return groupDto.Name;
        }

        public string GetConnectionId()
        {
            return this.Context.ConnectionId;
        }

        public override Task OnConnectedAsync()
        {
            Trace.TraceInformation("MapHub started. ID: {0}", Context.ConnectionId);

            var userName = "testUserName1"; // or get it from Context.User.Identity.Name;

            // Try to get a List of existing user connections from the cache
            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(userName, out existingUserConnectionIds);

            // happens on the very first connection from the user
            if (existingUserConnectionIds == null)
            {
                existingUserConnectionIds = new List<string>();
            }

            // First add to a List of existing user connections (i.e. multiple web browser tabs)
            existingUserConnectionIds.Add(Context.ConnectionId);


            // Add to the global dictionary of connected users
            ConnectedUsers.TryAdd(userName, existingUserConnectionIds);

            return Task.CompletedTask;
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
            await Clients.Group(room?.Name)?.SendAsync("userJoined");

            //Remove from list
            var userName = Context.User.Identity.Name;

            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(userName, out existingUserConnectionIds);

            // remove the connection id from the List 
            existingUserConnectionIds.Remove(Context.ConnectionId);

            // If there are no connection ids in the List, delete the user from the global cache (ConnectedUsers).
            if (existingUserConnectionIds.Count == 0)
            {
                // if there are no connections for the user,
                // just delete the userName key from the ConnectedUsers concurent dictionary
                List<string> garbage; // to be collected by the Garbage Collector
                ConnectedUsers.TryRemove(userName, out garbage);
            }

        }

        public async Task Refresh(string groupName)
        {
            await Clients.Group(groupName)?.SendAsync("refresh");
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("broadcastMessage", message);
        }
    }
}
