using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore
{
    public class WritingTaskManager : DTOManager<WritingTask, WritingTaskDto>, IWritingTaskDto
    {
        protected readonly IWritingTaskRepository _WritingTaskRepository;
        protected readonly IWritingQuizRepository _WritingQuizRepository;
        public WritingTaskManager(IWritingTaskRepository _db, IWritingQuizRepository _dbQ, DTOMapper<WritingTask, WritingTaskDto> mapper) : base(mapper)
        {
            _WritingTaskRepository = _db;
            _WritingQuizRepository = _dbQ;
        }
        public async Task<bool> AddNew(WritingTaskDto obj)
        {

            var entity = _DTOMapper.Map(obj);
            entity.WritingQuiz = _WritingQuizRepository.GetAllQuizzes().Where(x => x.Id == obj.WritingQuizId).FirstOrDefault();
            return await _WritingTaskRepository.AddNew(entity);
        }

        public async Task<WritingTaskDto> FindTask(int id)
        {
            var taskDb = await _WritingTaskRepository.FindTask(id);
            taskDb.WritingQuiz = await _WritingQuizRepository.FindQuiz(taskDb.WritingQuizId);
            var taskDto = _DTOMapper.Map(taskDb);
            return taskDto;
        }
        public async Task<bool> ModifyTask(WritingTaskDto obj)
        {
            var entity = _DTOMapper.Map(obj);
            return await _WritingTaskRepository.ModifyTask(entity);
        }

        public async Task<bool> Delete(WritingTaskDto obj)
        {
            var entity = _DTOMapper.Map(obj);
            return await _WritingTaskRepository.Delete(entity);
        }
        public async Task<IEnumerable<WritingTaskDto>> GetAllValues()
        {
            var encPositions = await _WritingTaskRepository.GetAllValues();
            return _DTOMapper.Map(encPositions);
        }
    }
}
