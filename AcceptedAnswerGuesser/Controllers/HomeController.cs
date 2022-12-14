using AcceptedAnswerGuesser.Models;
using AcceptedAnswerGuesser.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AcceptedAnswerGuesser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var apiService = new ApiService();
            var questions = await apiService.GetQuestionsAsync();
            return View(questions);
        }

        public async Task<IActionResult> Question(int id, string body)
        {
            var apiService = new ApiService();
            var answers = await apiService.GetAnswersAsync(id);

            GuesserModel guesser = new GuesserModel()
            {
                QuestionBody = body,
                Answers = answers
            };

            return View(guesser);
        }

        public IActionResult Answer(bool isAccepted)
        {
            GuessModel guess = new GuessModel()
            {
                isAccepted = isAccepted
            };

            return View(guess);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}