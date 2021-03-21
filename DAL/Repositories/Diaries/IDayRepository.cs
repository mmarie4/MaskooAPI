using DAL.Entities.Diaries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Diaries
{
    public interface IDayRepository : IRepository<Day>
    {
        Task<Day> GetByDateAsync(DateTime date);
        Task<ICollection<Day>> GetByFromToDatesAsync(DateTime from, DateTime to);
    }
}
