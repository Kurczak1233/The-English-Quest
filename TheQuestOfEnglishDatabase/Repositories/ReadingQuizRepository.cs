using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class ReadingQuizRepository : BaseRepository<ReadingQuiz>, IReadingQuizRepository
    {
        protected override DbSet<ReadingQuiz> DbSet => _db.ReadingQuizes;
        public ReadingQuizRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<bool> AddNewQuiz(ReadingQuiz quiz, string userId)
        {
            await DbSet.AddAsync(quiz);
            return await SaveChanges();
        }

        public async Task<bool> RemoveQuiz(ReadingQuiz quiz)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == quiz.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> ModifyQuiz(ReadingQuiz quiz)
        {
            DbSet.Update(quiz);
            return await SaveChanges();
        }
        public async Task<ReadingQuiz> FindQuiz(int id)
        {
            var quiz = await DbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
            return quiz;
        }
        public async Task<ReadingQuiz> FindQuizByName(string name)
        {
            return await DbSet.Where(x => x.Name == name).SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<ReadingQuiz>> GetAllQuizzesFiltered(string level)
        {
            return await DbSet.Where(x => x.Level == level).ToListAsync();
        }
        public IEnumerable<ReadingQuiz> GetAllQuizzes()
        {
            return DbSet.Select(x => x);
        }
    }
}
