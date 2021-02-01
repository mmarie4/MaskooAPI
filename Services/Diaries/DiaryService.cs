using System;
using System.Threading.Tasks;
using DAL.Entities.Diaries;
using DAL.Entities.Diary;
using DAL.Repositories.Diaries;

namespace Services.Diaries
{
    public class DiaryService : IDiaryService
    {

        private readonly IDiaryRepository _diaryRepository;

        public DiaryService(IDiaryRepository diaryRepository)
        {
            _diaryRepository = diaryRepository;
        }

        public async Task<Diary> GetDiaryAsync(Guid userId, DateTime? from, DateTime? to) {
            return await _diaryRepository.GetByUserIdAsync(userId);
        }

        public async Task<Diary> CreateDiaryAsync(Guid userId) {
            var parameter = new Diary() {
                Id = new Guid(),
                UserId = userId
            };
            var diary = await _diaryRepository.AddAsync(parameter);
            await _diaryRepository.SaveAsync();

            return diary;
        }

        public async Task<Diary> AddDayAsync(Guid userId, Guid diaryId) {
            var diary = await _diaryRepository.GetByUserIdAsync(userId);
            var day = new Day()
            {
                Id = new Guid(),
                DiaryId = diaryId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userId
            };
            diary.Days.Add(day);
            diary.UpdatedAt = DateTime.UtcNow;
            diary.UpdatedBy = userId;
            var result = _diaryRepository.Update(diary);
            await _diaryRepository.SaveAsync();
            return result;
        }
    }
}
