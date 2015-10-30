using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kwisspel.Models;

namespace Kwisspel.DAL
{
    class CategoryDBAcess
    {
        QuizContext quizContext;

        public CategoryDBAcess()
        {
            quizContext = QuizContext.Instance;
        }

        public void Insert(Category entity)
        {
            quizContext.Categories.Add(entity);
            quizContext.SaveChanges();
        }
        public void Delete(Category entity)
        {
            quizContext.Categories.Remove(entity);
            quizContext.SaveChanges();
        }
        public void Update(Category entity)
        {
            var result = quizContext.Categories.SingleOrDefault(c => c.Id == entity.Id);
            result = entity;
            quizContext.SaveChanges();
        }
        public Category Show(int id)
        {
            return quizContext.Categories.Find(id);
        }
        public List<Category> All()
        {
            return quizContext.Categories.ToList();
        }
    }
}
