using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuizGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizGame.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private static List<QuizQuestion> AllQuestions = new List<QuizQuestion>
        {
            // General Knowledge
            new QuizQuestion { Id = 1, Genre = "General Knowledge", Question = "What is the capital of France?", Options = new List<string> { "London", "Berlin", "Paris", "Madrid" }, CorrectOption = 2 },
            new QuizQuestion { Id = 2, Genre = "General Knowledge", Question = "Which planet is known as the Red Planet?", Options = new List<string> { "Earth", "Mars", "Jupiter", "Venus" }, CorrectOption = 1 },
            new QuizQuestion { Id = 3, Genre = "General Knowledge", Question = "What is H2O commonly known as?", Options = new List<string> { "Hydrogen", "Oxygen", "Water", "Salt" }, CorrectOption = 2 },
            new QuizQuestion { Id = 4, Genre = "General Knowledge", Question = "Who wrote 'Romeo and Juliet'?", Options = new List<string> { "Charles Dickens", "William Shakespeare", "Mark Twain", "Jane Austen" }, CorrectOption = 1 },
            new QuizQuestion { Id = 5, Genre = "General Knowledge", Question = "What is the largest mammal?", Options = new List<string> { "Elephant", "Blue Whale", "Giraffe", "Hippopotamus" }, CorrectOption = 1 },
            new QuizQuestion { Id = 6, Genre = "General Knowledge", Question = "How many continents are there?", Options = new List<string> { "5", "6", "7", "8" }, CorrectOption = 2 },
            new QuizQuestion { Id = 7, Genre = "General Knowledge", Question = "Which gas do plants absorb?", Options = new List<string> { "Oxygen", "Nitrogen", "Carbon Dioxide", "Helium" }, CorrectOption = 2 },
            new QuizQuestion { Id = 8, Genre = "General Knowledge", Question = "Who painted the Mona Lisa?", Options = new List<string> { "Michelangelo", "Leonardo da Vinci", "Raphael", "Donatello" }, CorrectOption = 1 },
            new QuizQuestion { Id = 9, Genre = "General Knowledge", Question = "What is the boiling point of water (°C)?", Options = new List<string> { "90", "100", "110", "120" }, CorrectOption = 1 },
            new QuizQuestion { Id = 10, Genre = "General Knowledge", Question = "Which language is most spoken worldwide?", Options = new List<string> { "English", "Mandarin Chinese", "Spanish", "Hindi" }, CorrectOption = 1 },

            // Movies
            new QuizQuestion { Id = 11, Genre = "Movies", Question = "Who played Iron Man in the MCU?", Options = new List<string> { "Chris Evans", "Robert Downey Jr.", "Chris Hemsworth", "Mark Ruffalo" }, CorrectOption = 1 },
            new QuizQuestion { Id = 12, Genre = "Movies", Question = "Which movie won the Oscar for Best Picture in 2020?", Options = new List<string> { "1917", "Parasite", "Joker", "Ford v Ferrari" }, CorrectOption = 1 },
            new QuizQuestion { Id = 13, Genre = "Movies", Question = "Who directed 'Jurassic Park'?", Options = new List<string> { "Steven Spielberg", "James Cameron", "George Lucas", "Peter Jackson" }, CorrectOption = 0 },
            new QuizQuestion { Id = 14, Genre = "Movies", Question = "What is the name of the wizarding school in Harry Potter?", Options = new List<string> { "Beauxbatons", "Durmstrang", "Hogwarts", "Ilvermorny" }, CorrectOption = 2 },
            new QuizQuestion { Id = 15, Genre = "Movies", Question = "Which actor voiced Woody in Toy Story?", Options = new List<string> { "Tom Hanks", "Tim Allen", "Billy Crystal", "Robin Williams" }, CorrectOption = 0 },
            new QuizQuestion { Id = 16, Genre = "Movies", Question = "Which movie features the quote 'I'll be back'?", Options = new List<string> { "Predator", "The Terminator", "Commando", "Total Recall" }, CorrectOption = 1 },
            new QuizQuestion { Id = 17, Genre = "Movies", Question = "Which movie is about a sinking ship?", Options = new List<string> { "Titanic", "Avatar", "Inception", "Jaws" }, CorrectOption = 0 },
            new QuizQuestion { Id = 18, Genre = "Movies", Question = "Who played the Joker in 'The Dark Knight'?", Options = new List<string> { "Heath Ledger", "Joaquin Phoenix", "Jack Nicholson", "Jared Leto" }, CorrectOption = 0 },
            new QuizQuestion { Id = 19, Genre = "Movies", Question = "Which movie is NOT a Marvel film?", Options = new List<string> { "Thor", "Black Panther", "Wonder Woman", "Ant-Man" }, CorrectOption = 2 },
            new QuizQuestion { Id = 20, Genre = "Movies", Question = "Which movie is about a magical nanny?", Options = new List<string> { "Mary Poppins", "Matilda", "Nanny McPhee", "The Sound of Music" }, CorrectOption = 0 },

            // Sports
            new QuizQuestion { Id = 21, Genre = "Sports", Question = "How many players in a football (soccer) team?", Options = new List<string> { "9", "10", "11", "12" }, CorrectOption = 2 },
            new QuizQuestion { Id = 22, Genre = "Sports", Question = "Which country hosted the 2016 Olympics?", Options = new List<string> { "China", "Brazil", "UK", "Russia" }, CorrectOption = 1 },
            new QuizQuestion { Id = 23, Genre = "Sports", Question = "Which sport uses a puck?", Options = new List<string> { "Baseball", "Ice Hockey", "Tennis", "Cricket" }, CorrectOption = 1 },
            new QuizQuestion { Id = 24, Genre = "Sports", Question = "What is the highest score in a single frame of snooker?", Options = new List<string> { "147", "155", "167", "180" }, CorrectOption = 0 },
            new QuizQuestion { Id = 25, Genre = "Sports", Question = "Who is known as the fastest man alive?", Options = new List<string> { "Usain Bolt", "Mo Farah", "Tyson Gay", "Yohan Blake" }, CorrectOption = 0 },
            new QuizQuestion { Id = 26, Genre = "Sports", Question = "Which country has won the most FIFA World Cups?", Options = new List<string> { "Germany", "Italy", "Brazil", "Argentina" }, CorrectOption = 2 },
            new QuizQuestion { Id = 27, Genre = "Sports", Question = "In which sport is the term 'love' used?", Options = new List<string> { "Tennis", "Football", "Basketball", "Cricket" }, CorrectOption = 0 },
            new QuizQuestion { Id = 28, Genre = "Sports", Question = "How many rings are there on the Olympic flag?", Options = new List<string> { "4", "5", "6", "7" }, CorrectOption = 1 },
            new QuizQuestion { Id = 29, Genre = "Sports", Question = "What is the national sport of Japan?", Options = new List<string> { "Karate", "Sumo Wrestling", "Judo", "Baseball" }, CorrectOption = 1 },
            new QuizQuestion { Id = 30, Genre = "Sports", Question = "Which sport is Michael Jordan famous for?", Options = new List<string> { "Baseball", "Football", "Basketball", "Golf" }, CorrectOption = 2 },
        };

        public IActionResult Index()
        {
            var genres = AllQuestions.Select(q => q.Genre).Distinct().ToList();
            return View(genres);
        }

        [HttpPost]
        public IActionResult Start(string genre)
        {
            var questions = AllQuestions
                .Where(q => q.Genre == genre)
                .OrderBy(x => Guid.NewGuid())
                .Take(10)
                .ToList();

            var model = new QuizViewModel
            {
                Genre = genre,
                Questions = questions,
                CurrentQuestionIndex = 0,
                Score = 0,
                UserAnswers = new List<int>()
            };
            TempData["QuizModel"] = System.Text.Json.JsonSerializer.Serialize(model);
            return RedirectToAction("Question");
        }

        public IActionResult Question()
        {
            var model = GetQuizModel();
            if (model == null || model.CurrentQuestionIndex >= model.Questions.Count)
                return RedirectToAction("Result");
            return View(model);
        }

        [HttpPost]
        public IActionResult Answer(int selectedOption)
        {
            var model = GetQuizModel();
            var currentQuestion = model.Questions[model.CurrentQuestionIndex];
            model.UserAnswers.Add(selectedOption);

            if (selectedOption == currentQuestion.CorrectOption)
                model.Score++;

            model.CurrentQuestionIndex++;
            TempData["QuizModel"] = System.Text.Json.JsonSerializer.Serialize(model);

            if (model.CurrentQuestionIndex >= model.Questions.Count)
                return RedirectToAction("Result");
            else
                return RedirectToAction("Question");
        }

        public IActionResult Result()
        {
            var model = GetQuizModel();
            return View(model);
        }

        private QuizViewModel GetQuizModel()
        {
            var json = TempData["QuizModel"] as string;
            if (string.IsNullOrEmpty(json))
                return null;
            TempData.Keep("QuizModel");
            return System.Text.Json.JsonSerializer.Deserialize<QuizViewModel>(json);
        }
    }
}
