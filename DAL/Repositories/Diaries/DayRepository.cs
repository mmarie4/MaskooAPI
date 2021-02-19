using DAL.Entities.Diaries;

namespace DAL.Repositories.Diaries
{
    public class DayRepository : Repository<Day>, IDayRepository
    {
        public DayRepository(AppDbContext context) : base(context)
        {
        }
    }
}
