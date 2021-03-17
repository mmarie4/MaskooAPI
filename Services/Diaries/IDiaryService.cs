using DAL.Entities.Diaries;
using Services.Diaries.Models;
using System;
using System.Threading.Tasks;

namespace Services.Diaries
{
    public interface IDiaryService
    {
        Task<Diary> GetDiaryAsync(Guid userId, DateTime? from, DateTime? to);

        Task<Diary> CreateDiaryAsync(Guid userId);

        Task<Diary> PatchDayContentAsync(Guid userId, Guid diaryId, DateTime date, DayUpdateParameter parameter);

    }
}
