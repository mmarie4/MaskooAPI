using DAL.Entities.Diaries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.Diaries
{
    public class DayRepository : Repository<Day>, IDayRepository
    {
        public DayRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Day> GetByDateAsync(DateTime date)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Date == date.Date);
        }

        public async Task<ICollection<Day>> GetByFromToDatesAsync(Guid diaryId, DateTime from, DateTime to)
        {
            return await Entities
                            .Where(d => d.DiaryId == diaryId
                                        && d.Date.Date >= from.Date
                                        && d.Date.Date < to.Date)
                            .ToListAsync();
        }
    }
}
