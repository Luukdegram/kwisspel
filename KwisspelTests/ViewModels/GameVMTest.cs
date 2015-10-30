using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Kwisspel.ViewModels;
using Kwisspel.DAL;
using Kwisspel.Models;
using System.Collections.Generic;

namespace KwisspelTests.ViewModels
{
    [TestClass]
    public class GameVMTest
    {
        private GameVM _gameVM;
        private Quiz _quiz;
        private List<Question> _questions;
        private List<Answer> _answers;

        [TestMethod]
        public void TestNextQuestion()
        {
            // Arrange
            _questions = new List<Question>();
            _questions.Add(new Question() { Id = 1, Description = "TestQuestionOne" });
            _questions.Add(new Question() { Id = 2, Description = "TestQuestionTwo" });

            _quiz = new Quiz() { Name = "TestQuiz", Questions = _questions };
            _gameVM = new GameVM(_quiz);

            // Act
            var firstId = _gameVM.CurrentQuestion.Id;
            var firstId_expected = 1;

            _gameVM.NextQuestion();

            var secondId = _gameVM.CurrentQuestion.Id;
            var secondId_expected = 2;

            // Assert
            Assert.AreEqual(firstId, firstId_expected);
            Assert.AreEqual(secondId, secondId_expected);
        }

        [TestMethod]
        public void TestSaveAnswer()
        {
            // Arrange
            _answers = new List<Answer>();
            _answers.Add(new Answer() { Id = 1, IsCorrect = false });
            _answers.Add(new Answer() { Id = 2, IsCorrect = true });

            _questions = new List<Question>();
            _questions.Add(new Question() { Id = 1, Description = "TestQuestionOne", Answers = _answers });
            _questions.Add(new Question() { Id = 2, Description = "TestQuestionTwo", Answers = _answers });

            _quiz = new Quiz() { Name = "TestQuiz", Questions = _questions };
            _gameVM = new GameVM(_quiz);

            // Act
            var firstScore = _gameVM.Score;
            var firstScore_expected = 0;

            _gameVM.selectAnswer("1"); // Answer with id 1 has IsCorrect = false
            var secondScore = _gameVM.Score;
            var secondScore_expected = 0;

            _gameVM.selectAnswer("2"); // Answer with id 2 has IsCorrect = true
            var thirdScore = _gameVM.Score;
            var thirdScore_expected = 1;

            // Assert
            Assert.AreEqual(firstScore, firstScore_expected);
            Assert.AreEqual(secondScore, secondScore_expected);
            Assert.AreEqual(thirdScore, thirdScore_expected);
        }
    }
}
