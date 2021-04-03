using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore
{
    public class WritingQuizManager : WritingQuizMapper, IWritingQuizDto
    {
        protected readonly IWritingQuizRepository _WritingQuizRepository;
        protected readonly IWritingTaskRepository _WritingTaskRepository;
        protected readonly IApplicationUserRepository _ApplicationUserRepository;
        protected readonly WritingQuizMapper _WritingQuizMapper;
        public WritingQuizManager(IWritingTaskRepository repo, WritingQuizMapper mapper, IWritingQuizRepository grammarQuizRepository, IApplicationUserRepository appuser)
        {
            _WritingQuizMapper = mapper;
            _WritingQuizRepository = grammarQuizRepository;
            _ApplicationUserRepository = appuser;
            _WritingTaskRepository = repo;
        }

        public async Task<bool> AddNewQuiz(WritingQuizDto quiz, string userId)
        {
            var user = await _ApplicationUserRepository.GetLoggedUser(userId);
            var entity = _WritingQuizMapper.Map(quiz);
            entity.User = user;
            entity.UserId = userId;
            return await _WritingQuizRepository.AddNewQuiz(entity, userId);
        }

        public async Task<bool> ModifyQuiz(WritingQuizDto quiz)
        {
            var entity = _WritingQuizMapper.Map(quiz);
            return await _WritingQuizRepository.ModifyQuiz(entity);
        }

        public async Task<WritingQuizDto> FindQuiz(int id)
        {
            var entity = await _WritingQuizRepository.FindQuiz(id);
            var user = await _ApplicationUserRepository.GetLoggedUser(entity.UserId);
            var result = await _WritingTaskRepository.GetAllValues();
            entity.WritingTasks = result.Where(x => x.WritingQuizId == entity.Id).ToList();
            entity.User = user;
            return _WritingQuizMapper.Map(entity);
        }

        public async Task<WritingQuizDto> FindQuizByName(string name)
        {
            var entity = await _WritingQuizRepository.FindQuizByName(name);
            var user = await _ApplicationUserRepository.GetLoggedUser(entity.UserId);
            entity.User = user;
            return _WritingQuizMapper.Map(entity);
        }

        public async Task<bool> RemoveQuiz(WritingQuizDto quiz)
        {
            var entity = _WritingQuizMapper.Map(quiz);
            return await _WritingQuizRepository.RemoveQuiz(entity);
        }

        public async Task<IEnumerable<WritingQuizDto>> GetAllQuizzesFiltered(string level)
        {
            var entities = await _WritingQuizRepository.GetAllQuizzesFiltered(level);
            foreach (var item in entities)
            {
                var user = await _ApplicationUserRepository.GetLoggedUser(item.UserId);
                item.User = user;
            }
            return _WritingQuizMapper.Map(entities);
        }

        public async Task<IEnumerable<WritingQuizDto>> GetAllQuizzes()
        {
            var entities = _WritingQuizRepository.GetAllQuizzes().ToList();
            foreach (var item in entities)
            {
                var user = await _ApplicationUserRepository.GetLoggedUser(item.UserId);
                item.User = user;
            }
            return _WritingQuizMapper.Map(entities);
        }
    }
}
