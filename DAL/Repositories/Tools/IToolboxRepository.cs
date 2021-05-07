using DAL.Entities.Tools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Tools
{
    public interface IToolboxRepository : IRepository<Toolbox>
    {
        Task<ICollection<Toolbox>> GetAllByUserId(Guid userId, string searchTerm);
    }
}
