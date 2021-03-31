﻿using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public interface IGrammarQuiz
    {
        Task<bool> AddNewQuiz(GrammarQuizDto quiz, string userId);
        Task<bool> RemoveQuiz(GrammarQuizDto quiz);
        Task<GrammarQuizDto> FindQuiz(int id);
        Task<GrammarQuizDto> FindQuizByName(string name);
    }
}
