using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kwisspel.Models;
using System.ComponentModel;

namespace Kwisspel.ViewModels
{
    public class CategoryVM: INotifyPropertyChanged
    {
        private Category _category;
        public Category Category { get { return _category; } }

        public string Name { 
            get { return _category.Name; }
            set { _category.Name = value; RaisePropertyChanged("Name"); }
        }

        public int Id
        {
            get { return _category.Id; }
            set { _category.Id = value; RaisePropertyChanged("Id"); }
        }

        public CategoryVM() { _category = new Category(); }
        public CategoryVM(Category category) { _category = category; }
        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
