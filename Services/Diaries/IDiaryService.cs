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

        Task<Diary> AddDayAsync(Guid userId, Guid diaryId, DateTime date);

        Task<Diary> UpdateDayAsync(Guid userId, Guid diaryId, Guid dayId, DayUpdateParameter updateDayParameter);

        Task<Diary> RemoveDayAsync(Guid diaryId, Guid dayId);
    }
}
