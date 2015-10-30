using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kwisspel.Models;

namespace Kwisspel.DAL
{
    class QuestionDBAccess
    {
        QuizContext quizContext;

        public QuestionDBAccess()
        {
            quizContext = QuizContext.Instance;
        }

        public void Insert(Question entity)
        {
            quizContext.Questions.Add(entity);
            quizContext.SaveChanges();
        }
        public void Delete(Question entity)
        {
            if (entity.Answers != null)
            {
                foreach (Answer answer in entity.Answers.ToList())
                {
                    quizContext.Answers.Remove(answer);
                }
            }
            quizContext.Questions.Remove(entity);
            quizContext.SaveChanges();
        }
        public void Update(Question entity)
        {
            var result = quizContext.Questions.SingleOrDefault(q => q.Id == entity.Id);
            result = entity;
            quizContext.SaveChanges();
        }
        public Question Show(int id)
        {
            return quizContext.Questions.Find(id);
        }
        public List<Question> All()
        {
            return quizContext.Questions.ToList();
        }
    }
}
