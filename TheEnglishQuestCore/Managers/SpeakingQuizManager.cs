using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestCore.Interfaces;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore
{
    public class SpeakingQuizManager : SpeakingQuizMapper, ISpeakingQuizDto
    {
        protected readonly ISpeakingQuizRepository _SpeakingQuizRepository;
        protected readonly ISpeakingTaskRepository _SpeakingTaskRepository;
        protected readonly IApplicationUserRepository _ApplicationUserRepository;
        protected readonly SpeakingQuizMapper _SpeakingQuizMapper;
        public SpeakingQuizManager(ISpeakingTaskRepository repo, SpeakingQuizMapper mapper, ISpeakingQuizRepository grammarQuizRepository, IApplicationUserRepository appuser)
        {
            _SpeakingQuizMapper = mapper;
            _SpeakingQuizRepository = grammarQuizRepository;
            _ApplicationUserRepository = appuser;
            _SpeakingTaskRepository = repo;
        }

        public async Task<bool> AddNewQuiz(SpeakingQuizDto quiz, string userId)
        {
            var user = await _ApplicationUserRepository.GetLoggedUser(userId);
            var entity = _SpeakingQuizMapper.Map(quiz);
            entity.User = user;
            entity.UserId = userId;
            return await _SpeakingQuizRepository.AddNewQuiz(entity, userId);
        }

        public async Task<bool> ModifyQuiz(SpeakingQuizDto quiz)
        {
            var entity = _SpeakingQuizMapper.Map(quiz);
            return await _SpeakingQuizRepository.ModifyQuiz(entity);
        }

        public async Task<SpeakingQuizDto> FindQuiz(int id)
        {
            var entity = await _SpeakingQuizRepository.FindQuiz(id);
            var user = await _ApplicationUserRepository.GetLoggedUser(entity.UserId);
            var result = await _SpeakingTaskRepository.GetAllValues();
            entity.SpeakingTasks = result.Where(x => x.SpeakingQuizId == entity.Id).ToList();
            entity.User = user;
            return _SpeakingQuizMapper.Map(entity);
        }

        public async Task<SpeakingQuizDto> FindQuizByName(string name)
        {
            var entity = await _SpeakingQuizRepository.FindQuizByName(name);
            var user = await _ApplicationUserRepository.GetLoggedUser(entity.UserId);
            entity.User = user;
            return _SpeakingQuizMapper.Map(entity);
        }

        public async Task<bool> RemoveQuiz(SpeakingQuizDto quiz)
        {
            var entity = _SpeakingQuizMapper.Map(quiz);
            return await _SpeakingQuizRepository.RemoveQuiz(entity);
        }

        public async Task<IEnumerable<SpeakingQuizDto>> GetAllQuizzesFiltered(string level)
        {
            var entities = await _SpeakingQuizRepository.GetAllQuizzesFiltered(level);
            foreach (var item in entities)
            {
                var user = await _ApplicationUserRepository.GetLoggedUser(item.UserId);
                item.User = user;
            }
            return _SpeakingQuizMapper.Map(entities);
        }

        public async Task<IEnumerable<SpeakingQuizDto>> GetAllQuizzes()
        {
            var entities = _SpeakingQuizRepository.GetAllQuizzes().ToList();
            foreach (var item in entities)
            {
                var user = await _ApplicationUserRepository.GetLoggedUser(item.UserId);
                item.User = user;
            }
            return _SpeakingQuizMapper.Map(entities);
        }
    }
}
