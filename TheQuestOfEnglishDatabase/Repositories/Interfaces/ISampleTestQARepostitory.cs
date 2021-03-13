using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestDatabase.Repositories.Interfaces
{
    public interface ISampleTestQARepostitory
    {
        Task<bool> Delete(SampleTestQA entity);
        Task<bool> AddNew(SampleTestQA entity);
        Task<IEnumerable<SampleTestQA>> GetAllValues();
    }
}
