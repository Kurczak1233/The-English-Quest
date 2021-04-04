using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class SpeakingQuizRepository : BaseRepository<SpeakingQuiz>, ISpeakingQuizRepository
    {
        protected override DbSet<SpeakingQuiz> DbSet => _db.SpeakingQuizzes;
        public SpeakingQuizRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<bool> AddNewQuiz(SpeakingQuiz quiz, string userId)
        {
            await DbSet.AddAsync(quiz);
            return await SaveChanges();
        }

        public async Task<bool> RemoveQuiz(SpeakingQuiz quiz)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == quiz.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> ModifyQuiz(SpeakingQuiz quiz)
        {
            DbSet.Update(quiz);
            return await SaveChanges();
        }
        public async Task<SpeakingQuiz> FindQuiz(int id)
        {
            var quiz = await DbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
            return quiz;
        }
        public async Task<SpeakingQuiz> FindQuizByName(string name)
        {
            return await DbSet.Where(x => x.Name == name).SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<SpeakingQuiz>> GetAllQuizzesFiltered(string level)
        {
            return await DbSet.Where(x => x.Level == level).ToListAsync();
        }
        public IEnumerable<SpeakingQuiz> GetAllQuizzes()
        {
            return DbSet.Select(x => x);
        }
    }
}
