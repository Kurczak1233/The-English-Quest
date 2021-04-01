using System.Collections.Generic;

namespace TheEnglishQuestCore
{
    public interface IDTOMapper<Entity, EntityDto>
    {
        EntityDto Map(Entity position);
        IEnumerable<EntityDto> Map(IEnumerable<Entity> positions);
        Entity Map(EntityDto position);
        IEnumerable<Entity> Map(IEnumerable<EntityDto> positions);
    }
}
