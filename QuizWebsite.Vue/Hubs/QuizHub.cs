using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizWebsite.Vue.Hubs
{
    public class QuizHub : Hub
    {
        public async Task MoveShape(int x, int y)
        {
            await Clients.Others.SendAsync("shapergereMovejd", x, y);
            HttpClient httpClient = new HttpClient();
            var a = await httpClient.GetAsync("");
            var result = a.Content;
        }
    }
}
