using Kwisspel.Controls;
using Kwisspel.Models;
using Kwisspel.View;
using System.ComponentModel;
using System.Windows.Input;

namespace Kwisspel.ViewModels
{
    public class QuizVM : INotifyPropertyChanged
    {
        private Quiz _quiz;

        public Quiz Quiz { get { return _quiz; } }
        public string Name
        {
            get { return _quiz.Name; }
            set { _quiz.Name = value; RaisePropertyChanged("Name"); }
        }

        public int Id
        {
            get { return _quiz.Id; }
            set { _quiz.Id = value; RaisePropertyChanged("Id"); }
        }

        public ICommand OpenQuestionManager { get; set; }
        public ICommand PlayQuiz { get; set; }
        private QuestionManager questionManager;
        private PlayQuiz playQuiz;
 
        public QuizVM()
        {
            _quiz = new Quiz();
            OpenQuestionManager = new RelayCommand(OpenQM, canOpenQM);
            PlayQuiz = new RelayCommand(OpenPlayQuiz, canOpen);
        }
 
        public QuizVM(Quiz quiz)
        {
            _quiz = quiz;
            OpenQuestionManager = new RelayCommand(OpenQM, canOpenQM);
            PlayQuiz = new RelayCommand(OpenPlayQuiz, canOpen);
        }

        private void OpenQM(object parameter)
        {
            questionManager = new QuestionManager(_quiz);
            questionManager.Show();
        }

        private bool canOpenQM() { return true; }

        private bool canOpen()
        {
            if (_quiz.Questions != null && _quiz.Questions.Count > 1)
            {
                return true;
            }
            return false;
        }

        private void OpenPlayQuiz(object parameter)
        {
            playQuiz = new PlayQuiz(_quiz);
            playQuiz.Show();
        }


        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
