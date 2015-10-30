using Kwisspel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.ViewModels
{
    public class QuestionVM : INotifyPropertyChanged
    {
        private Question _question;
        public Question Question { get { return _question; } }

        public int Id
        {
            get { return _question.Id; }
            set { _question.Id = value; RaisePropertyChanged("Id"); }
        }

        public string Description
        {
            get { return _question.Description; }
            set { _question.Description = value; RaisePropertyChanged("Description"); }
        }

        public ObservableCollection<AnswerVM> Answers { get; set; }

        public Category Category
        {
            get { return _question.Category;  }
            set { _question.Category = value; RaisePropertyChanged("Category"); }
        }


        public QuestionVM()
        {
            _question = new Question();

            Answers = new ObservableCollection<AnswerVM>();
        }
        public QuestionVM(Question question)
        {
            _question = question;
            if (_question.Answers != null)
            {
                Answers = new ObservableCollection<AnswerVM>(_question.Answers.Select(a => new AnswerVM(a)));
            }
            else
            {
                Answers = new ObservableCollection<AnswerVM>();
            }
        }
        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
