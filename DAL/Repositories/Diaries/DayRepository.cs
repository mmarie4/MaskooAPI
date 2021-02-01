using DAL.Entities.Diary;

namespace DAL.Repositories.Diaries
{
    public class DayRepository : Repository<Day>, IDayRepository
    {
        public DayRepository(AppDbContext context) : base(context)
        {
        }
    }
}
