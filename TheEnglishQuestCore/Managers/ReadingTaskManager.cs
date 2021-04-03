using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore
{
    public class ReadingTaskManager : DTOManager<ReadingTask, ReadingTaskDto>, IReadingTaskDto
    {
        protected readonly IReadingTaskRepository _ReadingTaskRepository;
        protected readonly IReadingQuizRepository _ReadingQuizRepository;
        public ReadingTaskManager(IReadingTaskRepository _db, IReadingQuizRepository _dbQ, DTOMapper<ReadingTask, ReadingTaskDto> mapper) : base(mapper)
        {
            _ReadingTaskRepository = _db;
            _ReadingQuizRepository = _dbQ;
        }
        public async Task<bool> AddNew(ReadingTaskDto obj)
        {

            var entity = _DTOMapper.Map(obj);
            entity.ReadingQuiz = _ReadingQuizRepository.GetAllQuizzes().Where(x => x.Id == obj.ReadingQuizId).FirstOrDefault();
            return await _ReadingTaskRepository.AddNew(entity);
        }

        public async Task<ReadingTaskDto> FindTask(int id)
        {
            var taskDb = await _ReadingTaskRepository.FindTask(id);
            taskDb.ReadingQuiz = await _ReadingQuizRepository.FindQuiz(taskDb.ReadingQuizId);
            var taskDto = _DTOMapper.Map(taskDb);
            return taskDto;
        }
        public async Task<bool> ModifyTask(ReadingTaskDto obj)
        {
            var entity = _DTOMapper.Map(obj);
            return await _ReadingTaskRepository.ModifyTask(entity);
        }

        public async Task<bool> Delete(ReadingTaskDto obj)
        {
            var entity = _DTOMapper.Map(obj);
            return await _ReadingTaskRepository.Delete(entity);
        }
        public async Task<IEnumerable<ReadingTaskDto>> GetAllValues()
        {
            var encPositions = await _ReadingTaskRepository.GetAllValues();
            return _DTOMapper.Map(encPositions);
        }
    }
}
