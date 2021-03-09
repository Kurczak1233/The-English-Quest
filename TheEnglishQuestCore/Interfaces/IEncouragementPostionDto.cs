using System;
using System.Collections.Generic;
using System.Text;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public interface IEncouragementPositionDto
    {
        void AddNewPosition(EncouragementPositionDto encPosition);
        bool DeletePosition(EncouragementPositionDto encPosition);
        List<EncouragementPositionDto> GetAllPositions();
    }
}
