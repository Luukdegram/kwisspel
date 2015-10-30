using Kwisspel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.DAL
{
    class QuizDBAccess : IDatabaseActions<Quiz>
    {
        QuizContext quizContext;

        public QuizDBAccess()
        {
            quizContext = QuizContext.Instance;
        }

        public void Insert(Quiz entity)
        {
            quizContext.Quizes.Add(entity);
            quizContext.SaveChanges();
        }
        public void Delete(Quiz entity)
        {
            if (entity.Questions != null)
            {
                foreach (Question question in entity.Questions.ToList())
                {
                    if (question.Answers != null)
                    {
                        foreach (Answer answer in question.Answers.ToList())
                        {
                            quizContext.Answers.Remove(answer);
                        }
                    }

                    quizContext.Questions.Remove(question);
                }
            }
            quizContext.Quizes.Remove(entity);
            quizContext.SaveChanges();
        }
        public void Update(Quiz entity)
        {
            var result = quizContext.Quizes.SingleOrDefault(q => q.Id == entity.Id);
            result = entity;
            quizContext.SaveChanges();
        }
        public Quiz Show(int id)
        {
            return quizContext.Quizes.Find(id);
        }
        public List<Quiz> All()
        {
            return quizContext.Quizes.ToList();
        }
    }
}
