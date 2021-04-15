using DAL.Entities.Notes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Notes
{
    public interface INoteRepository : IRepository<Note>
    {

        Task<ICollection<Note>> GetAllByUserId(Guid userId, string searchTerm);
    }
}
