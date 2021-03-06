using Microsoft.EntityFrameworkCore;
using System;

namespace TheQuestOfEnglishDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        
    }
}
