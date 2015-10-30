using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Kwisspel.Models;

namespace Kwisspel.DAL
{
    class QuizContext : DbContext
    {
        private static QuizContext quizContext;

        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }


        public QuizContext()
        {

        }

        public static QuizContext Instance
        {
            get
            {
                if (quizContext == null)
                {
                    quizContext = new QuizContext();
                }
                return quizContext;
            }
        }

    }
}
