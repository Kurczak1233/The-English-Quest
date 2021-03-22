using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase.Repositories
{
    public class PlacementTestTaskRepository : BaseRepository<PlacementTestTask>
    {
        protected override DbSet<PlacementTestTask> DbSet => _db.PlacementTestTasks;
        public PlacementTestTaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
