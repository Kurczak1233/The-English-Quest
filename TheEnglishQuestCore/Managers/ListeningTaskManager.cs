using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore
{
    public class ListeningTaskManager : DTOManager<ListeningTask, ListeningTaskDto>, IListeningTaskDto
    {
        protected readonly IListeningTaskRepository _ListeningTaskRepository;
        protected readonly IListeningQuizRepository _ListeningQuizRepository;
        public ListeningTaskManager(IListeningTaskRepository _db, IListeningQuizRepository _dbQ, DTOMapper<ListeningTask, ListeningTaskDto> mapper) : base(mapper)
        {
            _ListeningTaskRepository = _db;
            _ListeningQuizRepository = _dbQ;
        }
        public async Task<bool> AddNew(ListeningTaskDto obj)
        {

            var entity = _DTOMapper.Map(obj);
            entity.ListeningQuiz = _ListeningQuizRepository.GetAllQuizzes().Where(x => x.Id == obj.ListeningQuizId).FirstOrDefault();
            return await _ListeningTaskRepository.AddNew(entity);
        }

        public async Task<ListeningTaskDto> FindTask(int id)
        {
            var taskDb = await _ListeningTaskRepository.FindTask(id);
            taskDb.ListeningQuiz = await _ListeningQuizRepository.FindQuiz(taskDb.ListeningQuizId);
            var taskDto = _DTOMapper.Map(taskDb);
            return taskDto;
        }
        public async Task<bool> ModifyTask(ListeningTaskDto obj)
        {
            var entity = _DTOMapper.Map(obj);
            return await _ListeningTaskRepository.ModifyTask(entity);
        }

        public async Task<bool> Delete(ListeningTaskDto obj)
        {
            var entity = _DTOMapper.Map(obj);
            return await _ListeningTaskRepository.Delete(entity);
        }
        public async Task<IEnumerable<ListeningTaskDto>> GetAllValues()
        {
            var encPositions = await _ListeningTaskRepository.GetAllValues();
            return _DTOMapper.Map(encPositions);
        }
    }
}
