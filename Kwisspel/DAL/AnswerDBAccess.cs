using Kwisspel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.DAL
{
    class AnswerDBAccess
    {
        QuizContext quizContext;

        public AnswerDBAccess()
        {
            quizContext = QuizContext.Instance;
        }

        public void Insert(Answer entity)
        {
            quizContext.Answers.Add(entity);
            quizContext.SaveChanges();
        }
        public void Delete(Answer entity)
        {
            quizContext.Answers.Remove(entity);
            quizContext.SaveChanges();
        }
        public void Update(Answer entity)
        {
            var result = quizContext.Answers.SingleOrDefault(a => a.Id == entity.Id);
            result = entity;
            quizContext.SaveChanges();
        }
        public Answer Show(int id)
        {
            return quizContext.Answers.Find(id);
        }
        public List<Answer> All()
        {
            return quizContext.Answers.ToList();
        }
    }
}
