﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebsite.Web.Controllers
{
    public class SinglePlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Classic()
        {
            return View();
        }

        public IActionResult Unlimited()
        {
            return View();
        }
    }
}
