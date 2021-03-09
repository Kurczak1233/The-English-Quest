using System;
using System.Collections.Generic;
using System.Text;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase.Repositories.Interfaces
{
    public interface IEncouragementPositionRepository : IBaseRepository<EncouragementPosition>
    {
        List<EncouragementPosition> GetAllPositions();
    }
}
