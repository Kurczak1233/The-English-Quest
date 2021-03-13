using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestDatabase.Repositories.Interfaces
{
    public interface ISampleTestQADto
    {
        Task<bool> Delete(SampleTestQADto entity);
        Task<bool> AddNew(SampleTestQADto entity);
        Task<IEnumerable<SampleTestQADto>> GetAllValues();
    }
}
