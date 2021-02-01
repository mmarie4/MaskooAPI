using System;
using System.Threading.Tasks;
using DAL.Entities.Diaries;

namespace DAL.Repositories.Diaries
{
    public interface IDiaryRepository : IRepository<Diary>
    {
        Task<Diary> GetByUserIdAsync(Guid userId);
    }
}
