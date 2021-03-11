using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore.Interfaces
{
    public interface IEncouragementPositionDto
    {
        Task<bool> AddNewPosition(EncouragementPositionDto encPosition);
        Task<bool> DeletePosition(EncouragementPositionDto encPosition);
        Task<IEnumerable<EncouragementPositionDto>> GetAllPositions();
    }
}
