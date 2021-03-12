using System.Collections.Generic;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class DTOManager<Entity, EntityDto>
    {
        protected readonly DTOMapper<Entity, EntityDto> _DTOMapper;
        public DTOManager(DTOMapper<Entity, EntityDto> mapper)
        {
            _DTOMapper = mapper;
        }
    }
}
