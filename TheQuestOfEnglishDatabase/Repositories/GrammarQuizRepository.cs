using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase.Repositories
{
    class GrammarQuizRepository : BaseRepository<GrammarQuiz>, IGrammarQuizRepository
    {
        protected override DbSet<GrammarQuiz> DbSet => _db.Quizzes;
        public GrammarQuizRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<bool> AddNewQuiz(GrammarQuiz quiz)
        {
            await DbSet.AddAsync(quiz);
            return await SaveChanges();
        }

        public async Task<bool> RemoveQuiz(GrammarQuiz quiz)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == quiz.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> FindQuiz(int id)
        {
            return await DbSet.Select(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}
