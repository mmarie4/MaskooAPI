using System;
using System.Threading.Tasks;
using DAL.Entities.Diaries;

namespace Services.Diaries
{
    public interface IDiaryService
    {
        Task<Diary> GetDiaryAsync(Guid userId, DateTime? from, DateTime? to);

        Task<Diary> CreateDiaryAsync(Guid userId);

        Task<Diary> AddDayAsync(Guid userId, Guid diaryId);
    }
}
