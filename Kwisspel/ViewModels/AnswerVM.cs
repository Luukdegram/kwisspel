using Kwisspel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kwisspel.DAL;
using Kwisspel.Controls;

namespace Kwisspel.ViewModels
{
    public class AnswerVM : INotifyPropertyChanged
    {
        private Answer _answer;
        public Answer Answer { get { return _answer; } }
        private AnswerDBAccess dbContext;

        public string Description { 
            get { return _answer.Description; }
            set { _answer.Description = value; RaisePropertyChanged("Description"); }
        }

        public int Id
        {
            get { return _answer.Id; }
            set { _answer.Id = value; RaisePropertyChanged("Id"); }
        }

       public bool IsCorrect
        {
            get { return _answer.IsCorrect;  }
            set { _answer.IsCorrect = value; RaisePropertyChanged("IsCorrect"); }
        }

       public AnswerVM() { _answer = new Answer(); dbContext = new AnswerDBAccess(); }
       public AnswerVM(Answer answer) { _answer = answer; dbContext = new AnswerDBAccess(); }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
