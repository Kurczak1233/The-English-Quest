using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class GrammarQuizRepository : BaseRepository<GrammarQuiz>, IGrammarQuizRepository
    {
        protected override DbSet<GrammarQuiz> DbSet => _db.Quizzes;
        public GrammarQuizRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<bool> AddNewQuiz(GrammarQuiz quiz, string userId)
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

        public async Task<GrammarQuiz> FindQuiz(int id)
        {
            var quiz =  await DbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
            return quiz;
        }
        public async Task<GrammarQuiz> FindQuizByName(string name)
        {
            return await DbSet.Where(x => x.Name == name).SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<GrammarQuiz>> GetAllQuizzes()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }
    }
}
