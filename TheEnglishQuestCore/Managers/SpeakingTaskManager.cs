using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore
{
    public class SpeakingTaskManager : DTOManager<SpeakingTask, SpeakingTaskDto>, ISpeakingTaskDto
    {
        protected readonly ISpeakingTaskRepository _SpeakingTaskRepository;
        protected readonly ISpeakingQuizRepository _SpeakingQuizRepository;
        public SpeakingTaskManager(ISpeakingTaskRepository _db, ISpeakingQuizRepository _dbQ, DTOMapper<SpeakingTask, SpeakingTaskDto> mapper) : base(mapper)
        {
            _SpeakingTaskRepository = _db;
            _SpeakingQuizRepository = _dbQ;
        }
        public async Task<bool> AddNew(SpeakingTaskDto obj)
        {

            var entity = _DTOMapper.Map(obj);
            entity.SpeakingQuiz = _SpeakingQuizRepository.GetAllQuizzes().Where(x => x.Id == obj.SpeakingQuizId).FirstOrDefault();
            return await _SpeakingTaskRepository.AddNew(entity);
        }

        public async Task<SpeakingTaskDto> FindTask(int id)
        {
            var taskDb = await _SpeakingTaskRepository.FindTask(id);
            taskDb.SpeakingQuiz = await _SpeakingQuizRepository.FindQuiz(taskDb.SpeakingQuizId);
            var taskDto = _DTOMapper.Map(taskDb);
            return taskDto;
        }
        public async Task<bool> ModifyTask(SpeakingTaskDto obj)
        {
            var entity = _DTOMapper.Map(obj);
            return await _SpeakingTaskRepository.ModifyTask(entity);
        }

        public async Task<bool> Delete(SpeakingTaskDto obj)
        {
            var entity = _DTOMapper.Map(obj);
            return await _SpeakingTaskRepository.Delete(entity);
        }
        public async Task<IEnumerable<SpeakingTaskDto>> GetAllValues()
        {
            var encPositions = await _SpeakingTaskRepository.GetAllValues();
            return _DTOMapper.Map(encPositions);
        }
    }
}
