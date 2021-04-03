using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore
{
    public class ReadingQuizManager : ReadingQuizMapper, IReadingQuizDto
    {
        protected readonly IReadingQuizRepository _ReadingQuizRepository;
        protected readonly IReadingTaskRepository _ReadingTaskRepository;
        protected readonly IApplicationUserRepository _ApplicationUserRepository;
        protected readonly ReadingQuizMapper _readingQuizMapper;
        public ReadingQuizManager(IReadingTaskRepository repo, ReadingQuizMapper mapper, IReadingQuizRepository grammarQuizRepository, IApplicationUserRepository appuser)
        {
            _readingQuizMapper = mapper;
            _ReadingQuizRepository = grammarQuizRepository;
            _ApplicationUserRepository = appuser;
            _ReadingTaskRepository = repo;
        }

        public async Task<bool> AddNewQuiz(ReadingQuizDto quiz, string userId)
        {
            var user = await _ApplicationUserRepository.GetLoggedUser(userId);
            var entity = _readingQuizMapper.Map(quiz);
            entity.User = user;
            entity.UserId = userId;
            return await _ReadingQuizRepository.AddNewQuiz(entity, userId);
        }

        public async Task<bool> ModifyQuiz(ReadingQuizDto quiz)
        {
            var entity = _readingQuizMapper.Map(quiz);
            return await _ReadingQuizRepository.ModifyQuiz(entity);
        }

        public async Task<ReadingQuizDto> FindQuiz(int id)
        {
            var entity = await _ReadingQuizRepository.FindQuiz(id);
            var user = await _ApplicationUserRepository.GetLoggedUser(entity.UserId);
            var result = await _ReadingTaskRepository.GetAllValues();
            entity.ReadingTasks = result.Where(x => x.ReadingQuizId == entity.Id).ToList();
            entity.User = user;
            return _readingQuizMapper.Map(entity);
        }

        public async Task<ReadingQuizDto> FindQuizByName(string name)
        {
            var entity = await _ReadingQuizRepository.FindQuizByName(name);
            var user = await _ApplicationUserRepository.GetLoggedUser(entity.UserId);
            entity.User = user;
            return _readingQuizMapper.Map(entity);
        }

        public async Task<bool> RemoveQuiz(ReadingQuizDto quiz)
        {
            var entity = _readingQuizMapper.Map(quiz);
            return await _ReadingQuizRepository.RemoveQuiz(entity);
        }

        public async Task<IEnumerable<ReadingQuizDto>> GetAllQuizzesFiltered(string level)
        {
            var entities = await _ReadingQuizRepository.GetAllQuizzesFiltered(level);
            foreach (var item in entities)
            {
                var user = await _ApplicationUserRepository.GetLoggedUser(item.UserId);
                item.User = user;
            }
            return _readingQuizMapper.Map(entities);
        }

        public async Task<IEnumerable<ReadingQuizDto>> GetAllQuizzes()
        {
            var entities = _ReadingQuizRepository.GetAllQuizzes().ToList();
            foreach (var item in entities)
            {
                var user = await _ApplicationUserRepository.GetLoggedUser(item.UserId);
                item.User = user;
            }
            return _readingQuizMapper.Map(entities);
        }
    }
}
