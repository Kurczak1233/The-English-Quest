﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase.Repositories.Interfaces;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class EncouragementPositionRepository : BaseRepository<EncouragementPosition>, IEncouragementPositionRepository
    {
        protected override DbSet<EncouragementPosition> DbSet => _db.EncouragementPositions;
        public EncouragementPositionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<EncouragementPosition> GetAllPositions()
        {
            return DbSet.Select(x => x);
        }
    }
}