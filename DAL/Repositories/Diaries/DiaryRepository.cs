using System;
using System.Threading.Tasks;
using DAL.Entities.Diaries;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Diaries
{
    public class DiaryRepository : Repository<Diary>, IDiaryRepository
    {
        public DiaryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Diary> GetByUserIdAsync(Guid userId)
        {
            return await Entities.Include(d => d.Days).FirstOrDefaultAsync(d => d.UserId == userId);
        }
    }
}
