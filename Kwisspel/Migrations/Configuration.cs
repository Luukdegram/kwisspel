namespace Kwisspel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kwisspel.DAL.QuizContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /**
         * Adds seed data to the database.
         * Provides a full quiz game.
         */
        protected override void Seed(Kwisspel.DAL.QuizContext context)
        {
            // Quizes seed data
            context.Quizes.AddOrUpdate(
                q => q.Id,
                new Models.Quiz { Id = 1, Name = "The awesome programming quiz!" });

            // Categories seed data
            context.Categories.AddOrUpdate(
                c => c.Id,
                new Models.Category { Id = 1, Name = "Programming" },
                new Models.Category { Id = 2, Name = "Gaming" });

            // Questions seed data
            
            context.Questions.AddOrUpdate(
                q => q.Id,
                new Models.Question { Id = 1, Description = "What is the best programming language?", Quiz = context.Quizes.Find(1), Category = context.Categories.Find(1) });

            // Answers seed data
            context.Answers.AddOrUpdate(
                a => a.Id,
                new Models.Answer { Id = 1, Description = "Java", IsCorrect = true, Question = context.Questions.Find(1) },
                new Models.Answer { Id = 2, Description = "C++", IsCorrect = true, Question = context.Questions.Find(1) },
                new Models.Answer { Id = 3, Description = "C#", IsCorrect = false, Question = context.Questions.Find(1) },
                new Models.Answer { Id = 4, Description = "Python", IsCorrect = false, Question = context.Questions.Find(1) });
             
        }
    }
}
