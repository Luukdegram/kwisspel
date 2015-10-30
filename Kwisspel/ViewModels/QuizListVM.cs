using Kwisspel.Controls;
using Kwisspel.DAL;
using Kwisspel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kwisspel.ViewModels
{
    public class QuizListVM : INotifyPropertyChanged
    {
        private QuizVM _quiz { get; set; }
        public ObservableCollection<QuizVM> Quizes { get; set; }
        public ICommand SaveQuiz { get; set; }
        public ICommand DeleteQuiz { get; set; }
        public ICommand ClearQuiz { get; set; }
        public QuizVM SelectedQuiz { get { return _quiz; } set { _quiz = value; RaisePropertyChanged("SelectedQuiz"); } }
        private QuizDBAccess dbContext;
        public QuizListVM ()
        {
            dbContext = new QuizDBAccess();
            var quizList = dbContext.All().Select(q => new QuizVM(q));

            SelectedQuiz = new QuizVM();
            Quizes = new ObservableCollection<QuizVM>(quizList);
            SaveQuiz = new RelayCommand(AddOrUpdateQuiz, canSave);
            DeleteQuiz = new RelayCommand(RemoveQuiz, canRemove);
            ClearQuiz = new RelayCommand(ClearSelectedQuiz, canClear);
        }

        private bool canSave() { return true; }

        private void AddOrUpdateQuiz(object parameter)
        {
            if (_quiz.Id != 0) // Update selected quiz
            {
                dbContext.Update(_quiz.Quiz);
            }
            else // Add new quiz
            {
                Quizes.Add(_quiz);
                dbContext.Insert(_quiz.Quiz);
            }

            SelectedQuiz = new QuizVM();            
        }

        private void RemoveQuiz(object parameter)
        {
            dbContext.Delete(_quiz.Quiz);
            Quizes.Remove(_quiz);
            SelectedQuiz = new QuizVM();
        }

        private bool canRemove()
        {
            return _quiz.Id != 0;
        }

        private void ClearSelectedQuiz(object parameter)
        {
            SelectedQuiz = new QuizVM();
        }

        private bool canClear()
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
