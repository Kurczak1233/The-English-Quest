using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase.Repositories.Interfaces;

namespace TheEnglishQuestCore.Managers
{
    public class SampleTestQAManager : DTOManager<SampleTestQA, SampleTestQADto>, ISampleTestQADto
    {
        protected readonly ISampleTestQARepostitory _SampleTestQARepostory;
        public SampleTestQAManager(ISampleTestQARepostitory _db, DTOMapper<SampleTestQA, SampleTestQADto> mapper) : base(mapper)
        {
            _SampleTestQARepostory = _db;
        }

        public async Task<bool> AddNew(SampleTestQADto obj)
        {

            var entity = _DTOMapper.Map(obj);
            return await _SampleTestQARepostory.AddNew(entity);
        }


        public async Task<bool> Delete(SampleTestQADto obj)
        {
            var entity = _DTOMapper.Map(obj);
            return await _SampleTestQARepostory.Delete(entity);
        }

        public async Task<IEnumerable<SampleTestQADto>> GetAllValues()
        {
            var encPositions = await _SampleTestQARepostory.GetAllValues();
            return _DTOMapper.Map(encPositions);
        }
    }
}
