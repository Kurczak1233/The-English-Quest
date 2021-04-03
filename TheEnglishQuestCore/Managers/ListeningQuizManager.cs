using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore
{
    public class ListeningQuizManager : ListeningQuizMapper, IListeningQuizDto
    {
        protected readonly IListeningQuizRepository _ListeningQuizRepository;
        protected readonly IListeningTaskRepository _ListeningTaskRepository;
        protected readonly IApplicationUserRepository _ApplicationUserRepository;
        protected readonly ListeningQuizMapper _ListeningQuizMapper;
        public ListeningQuizManager(IListeningTaskRepository repo, ListeningQuizMapper mapper, IListeningQuizRepository listeningQuizRepository, IApplicationUserRepository appuser)
        {
            _ListeningQuizMapper = mapper;
            _ListeningQuizRepository = listeningQuizRepository;
            _ApplicationUserRepository = appuser;
            _ListeningTaskRepository = repo;
        }

        public async Task<bool> AddNewQuiz(ListeningQuizDto quiz, string userId)
        {
            var user = await _ApplicationUserRepository.GetLoggedUser(userId);
            var entity = _ListeningQuizMapper.Map(quiz);
            entity.User = user;
            entity.UserId = userId;
            return await _ListeningQuizRepository.AddNewQuiz(entity, userId);
        }

        public async Task<bool> ModifyQuiz(ListeningQuizDto quiz)
        {
            var entity = _ListeningQuizMapper.Map(quiz);
            return await _ListeningQuizRepository.ModifyQuiz(entity);
        }

        public async Task<ListeningQuizDto> FindQuiz(int id)
        {
            var entity = await _ListeningQuizRepository.FindQuiz(id);
            var user = await _ApplicationUserRepository.GetLoggedUser(entity.UserId);
            var result = await _ListeningTaskRepository.GetAllValues();
            entity.ListeningTasks = result.Where(x => x.ListeningQuizId == entity.Id).ToList();
            entity.User = user;
            return _ListeningQuizMapper.Map(entity);
        }

        public async Task<ListeningQuizDto> FindQuizByName(string name)
        {
            var entity = await _ListeningQuizRepository.FindQuizByName(name);
            var user = await _ApplicationUserRepository.GetLoggedUser(entity.UserId);
            entity.User = user;
            return _ListeningQuizMapper.Map(entity);
        }

        public async Task<bool> RemoveQuiz(ListeningQuizDto quiz)
        {
            var entity = _ListeningQuizMapper.Map(quiz);
            return await _ListeningQuizRepository.RemoveQuiz(entity);
        }

        public async Task<IEnumerable<ListeningQuizDto>> GetAllQuizzesFiltered(string level)
        {
            var entities = await _ListeningQuizRepository.GetAllQuizzesFiltered(level);
            foreach (var item in entities)
            {
                var user = await _ApplicationUserRepository.GetLoggedUser(item.UserId);
                item.User = user;
            }
            return _ListeningQuizMapper.Map(entities);
        }

        public async Task<IEnumerable<ListeningQuizDto>> GetAllQuizzes()
        {
            var entities = _ListeningQuizRepository.GetAllQuizzes().ToList();
            foreach (var item in entities)
            {
                var user = await _ApplicationUserRepository.GetLoggedUser(item.UserId);
                item.User = user;
            }
            return _ListeningQuizMapper.Map(entities);
        }
    }
}
