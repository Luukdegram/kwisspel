using Kwisspel.Models;
using Kwisspel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kwisspel.View
{
    /// <summary>
    /// Interaction logic for PlayQuiz.xaml
    /// </summary>
    public partial class PlayQuiz : Window
    {
        public PlayQuiz(Quiz quiz)
        {
            InitializeComponent();
            DataContext = new GameVM(quiz);
        }
    }
}
