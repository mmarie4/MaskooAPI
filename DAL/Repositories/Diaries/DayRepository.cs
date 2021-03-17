using DAL.Entities.Diaries;
using Microsoft.EntityFrameworkCore;
using System;
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
    }
}
