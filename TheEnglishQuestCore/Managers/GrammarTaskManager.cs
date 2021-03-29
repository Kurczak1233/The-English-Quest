using System.Collections.Generic;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Repositories.Interfaces;

namespace TheEnglishQuestCore
{
    public class GrammarTaskManager : DTOManager<GrammarTask, GrammarTaskDto>, IGrammarTaskDto
    {
        protected readonly IGrammarTaskRepository _GrammarTaskRepository;
        public GrammarTaskManager(IGrammarTaskRepository _db, DTOMapper<GrammarTask, GrammarTaskDto> mapper) : base(mapper)
        {
            _GrammarTaskRepository = _db;
        }
        public async Task<bool> AddNew(GrammarTaskDto obj)
        {

            var entity = _DTOMapper.Map(obj);
            return await _GrammarTaskRepository.AddNew(entity);
        }

        public async Task<bool> Delete(GrammarTaskDto obj)
        {
            var entity = _DTOMapper.Map(obj);
            return await _GrammarTaskRepository.Delete(entity);
        }
        public async Task<IEnumerable<GrammarTaskDto>> GetAllValues()
        {
            var encPositions = await _GrammarTaskRepository.GetAllValues();
            return _DTOMapper.Map(encPositions);
        }
    }
}
