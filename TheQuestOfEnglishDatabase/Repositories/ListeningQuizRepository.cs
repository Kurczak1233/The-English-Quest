using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class ListeningQuizRepository : BaseRepository<ListeningQuiz>, IListeningQuizRepository
    {
        protected override DbSet<ListeningQuiz> DbSet => _db.ListegningQuizes;
        public ListeningQuizRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<bool> AddNewQuiz(ListeningQuiz quiz, string userId)
        {
            await DbSet.AddAsync(quiz);
            return await SaveChanges();
        }

        public async Task<bool> RemoveQuiz(ListeningQuiz quiz)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == quiz.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }

        public async Task<bool> ModifyQuiz(ListeningQuiz quiz)
        {
            DbSet.Update(quiz);
            return await SaveChanges();
        }
        public async Task<ListeningQuiz> FindQuiz(int id)
        {
            var quiz = await DbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
            return quiz;
        }
        public async Task<ListeningQuiz> FindQuizByName(string name)
        {
            return await DbSet.Where(x => x.Name == name).SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<ListeningQuiz>> GetAllQuizzesFiltered(string level)
        {
            return await DbSet.Where(x => x.Level == level).ToListAsync();
        }
        public IEnumerable<ListeningQuiz> GetAllQuizzes()
        {
            return DbSet.Select(x => x);
        }
    }
}
