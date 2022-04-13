﻿using TestProjectWeb.Data;
using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Services
{
    public class QuizService
    {
        private UserRepository _userRepository;
        private UserService _userService;
        private WordRepository _wordRepository;
        private Random _random = new Random();

        public QuizService(UserRepository userRepository, UserService userService, WordRepository wordRepository)
        {
            _userRepository = userRepository;
            _userService = userService;
            _wordRepository = wordRepository;
        }

        public Quiz CreateQuiz(string quizTitle, int questionsQuantity)
        {
            var creater = _userService.GetCurrentUser();
            var questions = GetRandomQuestionsList(questionsQuantity);

            var quiz = new Quiz
            {
                Title = quizTitle,
                Creater = creater,
                Questions = questions,
            };

            return quiz;
        }

        private Question GetRandomQuestion()
        {
            var index = RandomIndex();
            var word = _wordRepository.GetRandomWord(index);
            var variants = GetVariants(word.Translation);
            var question = new Question { 
                Ask = word.Value,
                Answer = word.Translation,
                Variants = variants,
            };

            return question;
        }

        private List<Question> GetRandomQuestionsList(int quantity)
        {
            var result = new List<Question>();

            for (int i = 0; i < quantity; i++)
            {
                var question = GetRandomQuestion();
                if (result.Any(x=> x.Ask == question.Ask))
                {
                    i--;
                    continue;
                }
                result.Add(question);
            }
            return result;
        }

        private List<Variant> GetVariants(string answer)
        {
            var randomIndex = RandomIndex();
            var result = new List<Variant>();
            for (int i = 0; i < 3; i++)
            {
                var variant = _wordRepository.GetRandomWord(randomIndex).Translation;
                if (variant == answer ||result.Any(x => x.Value == variant))
                {
                    i--;
                    continue;
                }
            }

            return result;
        }

        private int RandomIndex()
        {
            var index = _random.Next(_wordRepository.GetAll().Count);
            return index;
        }
    }
}
