using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public interface IDTOManager
    {
         Task<bool> AddNewPosition(EncouragementPositionDto encPosition);
         Task<bool> DeletePosition(EncouragementPositionDto encPosition);
        List<EncouragementPositionDto> GetAllPositions();
    }
}
