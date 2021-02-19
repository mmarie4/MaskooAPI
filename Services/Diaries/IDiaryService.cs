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

        Task<Diary> AddDayAsync(Guid userId, DateTime date);

        Task<Diary> UpdateDayAsync(Guid diaryId, Guid dayId, UpdateDayParameter updateDayParameter, Guid userId);

        Task<Diary> RemoveDay(Guid diaryId, Guid dayId);
    }
}
