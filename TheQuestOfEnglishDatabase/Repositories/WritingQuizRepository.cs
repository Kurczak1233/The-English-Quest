using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class WritingQuizRepository : BaseRepository<WritingQuiz>, IWritingQuizRepository
    {
        protected override DbSet<WritingQuiz> DbSet => _db.WritingQuizzes;
        public WritingQuizRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<bool> AddNewQuiz(WritingQuiz quiz, string userId)
        {
            await DbSet.AddAsync(quiz);
            return await SaveChanges();
        }

        public async Task<bool> RemoveQuiz(WritingQuiz quiz)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == quiz.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> ModifyQuiz(WritingQuiz quiz)
        {
            DbSet.Update(quiz);
            return await SaveChanges();
        }
        public async Task<WritingQuiz> FindQuiz(int id)
        {
            var quiz = await DbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
            return quiz;
        }
        public async Task<WritingQuiz> FindQuizByName(string name)
        {
            return await DbSet.Where(x => x.Name == name).SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<WritingQuiz>> GetAllQuizzesFiltered(string level)
        {
            return await DbSet.Where(x => x.Level == level).ToListAsync();
        }
        public IEnumerable<WritingQuiz> GetAllQuizzes()
        {
            return DbSet.Select(x => x);
        }
    }
}
