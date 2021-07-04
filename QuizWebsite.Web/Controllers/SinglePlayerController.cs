using Microsoft.AspNetCore.Mvc;
using QuizWebsite.Core.Entities;
using QuizWebsite.Core.Interfaces;
using QuizWebsite.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebsite.Web.Controllers
{
    public class SinglePlayerController : Controller
    {
        private readonly IQuestionService questionService;
        public SinglePlayerController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
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
            var viewModel = new SinglePlayerUnlimitedVm()
            {
                Questions = questionService.GetQuestionsRandomOrder().ToList(),
                Player = new Player()
            };
            return View(viewModel);
        }
    }
}
