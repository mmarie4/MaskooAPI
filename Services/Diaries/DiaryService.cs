using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Entities.Diaries;
using DAL.Repositories.Diaries;
using Services.Diaries.Models;

namespace Services.Diaries
{
    public class DiaryService : IDiaryService
    {

        private readonly IDiaryRepository _diaryRepository;
        private readonly IDayRepository _dayRepository;

        public DiaryService(IDiaryRepository diaryRepository, IDayRepository dayRepository)
        {
            _diaryRepository = diaryRepository;
            _dayRepository = dayRepository;
        }

        public async Task<Diary> GetDiaryAsync(Guid userId, DateTime? from, DateTime? to) {
            var diary = await _diaryRepository.GetByUserIdAsync(userId);
            if (diary == null)
            {
                throw new Exception($"Diary not found for user {userId}");
            }

            return diary;
        }

        public async Task<Diary> CreateDiaryAsync(Guid userId) {
            var parameter = new Diary() {
                UserId = userId
            };
            parameter.Stamp(userId);
            var diary = await _diaryRepository.AddAsync(parameter);
            await _diaryRepository.SaveAsync();

            return diary;
        }

        public async Task<Diary> PatchDayContentAsync(Guid userId, Guid diaryId, DateTime date, DayUpdateParameter parameter)
        {
            var day = await _dayRepository.GetByDateAsync(date);
            if (day == null)
            {
                var _ = await AddDayAsync(userId, diaryId, date);
            }

            var diary = await UpdateDayAsync(userId, diaryId, day.Id, parameter);

            return diary;
        }

        private async Task<Diary> AddDayAsync(Guid userId, Guid diaryId, DateTime date) {

            var diary = await _diaryRepository.GetByIdAsync(diaryId);
            var day = new Day()
            {
                DiaryId = diary.Id,
                Date = date
            };
            
            day.Stamp(userId);
            await _dayRepository.AddAsync(day);

            diary.Stamp(userId, false);
            var result = await _diaryRepository.Update(diary);
            await _diaryRepository.SaveAsync();

            return result;
        }

        private async Task<Diary> UpdateDayAsync(Guid userId, Guid diaryId, Guid dayId, DayUpdateParameter updateDayParameter)
        {
            var day = await _dayRepository.GetByIdAsync(dayId);
            if (day == null)
            {
                throw new Exception($"Day not found with id {dayId}");
            }

            day.Content = updateDayParameter.Content;
            day.Stamp(userId, false);

            var result = await _dayRepository.Update(day);
            await _dayRepository.SaveAsync();

            return await _diaryRepository.GetByIdAsync(diaryId);
        }


    }
}
