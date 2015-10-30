using Kwisspel.Controls;
using Kwisspel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kwisspel.ViewModels
{
    public class GameVM : INotifyPropertyChanged
    {
        private Quiz quiz { get; set; }
        private QuestionVM _currentQuestion { get; set; }
        public QuestionVM CurrentQuestion { get { return _currentQuestion; } set { _currentQuestion = value;  RaisePropertyChanged("CurrentQuestion"); } }
        public Quiz Quiz { get { return quiz; } }
        public bool IsFinished { get { return isFinished; } set { isFinished = value; RaisePropertyChanged("IsFinished"); } }
        private bool isFinished { get; set; }
        public ICommand SelectAnswer { get; set; }
        public int Score { get { return currentScore; } set { currentScore = value; RaisePropertyChanged("Score"); } }
        private int currentScore { get; set; }
        private int currentQuestionIndex { get; set; }
        public GameVM(Quiz quiz)
        {
            this.quiz = quiz;
            CurrentQuestion = new QuestionVM(quiz.Questions.First());
            currentQuestionIndex = 1;
            currentScore = 0;
            IsFinished = false;
            SelectAnswer = new RelayCommand(selectAnswer, canSelect);
        }

        public void NextQuestion()
        {
            if (currentQuestionIndex < quiz.Questions.Count())
            {
                CurrentQuestion = new QuestionVM(quiz.Questions.ElementAt(currentQuestionIndex));
                currentQuestionIndex++;
            }
            else
            {
                IsFinished = true;
                CurrentQuestion = new QuestionVM();               
            }
        }

        public void selectAnswer(object parameter)
        {
            int answer = Int32.Parse(parameter.ToString());

            if (CurrentQuestion.Answers.ToList().Find(a => a.Id == answer).IsCorrect)
            {
                Score++;
            }

            NextQuestion();
        }

        private bool canSelect()
        {
            return true;
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
