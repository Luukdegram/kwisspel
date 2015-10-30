using Kwisspel.Controls;
using Kwisspel.DAL;
using Kwisspel.Models;
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
    public class QuestionListVM : INotifyPropertyChanged
    {

        private QuestionDBAccess questionContext;
        private CategoryDBAcess categoryContext;
        private AnswerDBAccess answerContext;
        private Quiz quiz { get; set; }
        private QuestionVM _question { get; set; }
        private AnswerVM _answer { get; set; }
        public QuestionVM SelectedQuestion { get { return _question; } set { _question = value; RaisePropertyChanged("SelectedQuestion"); } }
        public AnswerVM SelectedAnswer { get { return _answer; } set { _answer = value; RaisePropertyChanged("SelectedAnswer"); } }
        public ObservableCollection<QuestionVM> Questions { get; set; }
        public ObservableCollection<CategoryVM> Categories { get; set; }

        public ICommand SaveQuestion { get; set; }
        public ICommand SaveAnswer { get; set; }
        public ICommand DeleteQuestion { get; set; }
        public ICommand DeleteAnswer { get; set; }
        public ICommand ClearQuestion { get; set; }
        public ICommand ClearAnswer { get; set; }
        public QuestionListVM(Quiz quiz)
        {
            questionContext = new QuestionDBAccess();
            categoryContext = new CategoryDBAcess();
            answerContext = new AnswerDBAccess();

            this.quiz = quiz;
            SelectedQuestion = new QuestionVM();
            SelectedAnswer = new AnswerVM();

            if (quiz.Questions == null)
            {
                Questions = new ObservableCollection<QuestionVM>();
            }
            else
            {
                Questions = new ObservableCollection<QuestionVM>(quiz.Questions.Select(q => new QuestionVM(q)));
            }

            Categories = new ObservableCollection<CategoryVM>(categoryContext.All().Select(c => new CategoryVM(c)));

            SaveQuestion = new RelayCommand(saveQuestion, canSave);
            DeleteQuestion = new RelayCommand(removeQuestion, canRemove);
            ClearQuestion = new RelayCommand(clearQuestion, canClear);
            SaveAnswer = new RelayCommand(saveAnswer, canSaveAnswer);
            DeleteAnswer = new RelayCommand(deleteAnswer, canDelete);
            ClearAnswer = new RelayCommand(clearAnswer, canClear);
        }

        private void saveQuestion(object parameter)
        {
            if (_question.Id != 0) 
            {
                questionContext.Update(_question.Question);
            }
            else 
            {
                _question.Question.Quiz = quiz;
                Questions.Add(_question);
                questionContext.Insert(_question.Question);
            }
        }

        private bool canSave()
        {
            if (Questions.Count <= 10)
            {
                return true;
            }

            return false;
        }

        private void saveAnswer(object parameter)
        {
            if (_answer.Id != 0)
            {
                answerContext.Update(_answer.Answer);
            }
            else
            {
                _answer.Answer.Question = SelectedQuestion.Question;
                SelectedQuestion.Answers.Add(_answer);
                answerContext.Insert(_answer.Answer);
            }
        }

        private bool canSaveAnswer()
        {
            return SelectedQuestion.Answers == null || SelectedQuestion.Answers.Count < 4 || _answer.Id != 0;
        }

        private void removeQuestion(object parameter)
        {
            questionContext.Delete(_question.Question);
            Questions.Remove(_question);
            SelectedQuestion = new QuestionVM();
        }

        private bool canRemove()
        {
            return _question.Id != 0;
        }

        private void clearQuestion(object parameter)
        {
            SelectedQuestion = new QuestionVM();
        }

        private void clearAnswer(object parameter)
        {
            SelectedAnswer = new AnswerVM();
        }

        private bool canClearAnswer()
        {
            return true;
        }

        private bool canClear() { return true; }

        private void deleteAnswer(object parameter)
        {
            answerContext.Delete(_answer.Answer);
            SelectedQuestion.Answers.Remove(_answer);
            SelectedAnswer = new AnswerVM();
        }
        private bool canDelete()
        {
            return _answer != null &&_answer.Id != 0;
        }
       
        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
