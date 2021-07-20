using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebsite.Vue.Controllers
{
    public class MultiPlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClassicGame()
        {
            return View();
        }
    }
}
