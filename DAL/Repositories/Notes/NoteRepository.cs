using DAL.Entities.Notes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.Notes
{
    public class NoteRepository : Repository<Note>, INoteRepository 
    {
        public NoteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Note>> GetAllByUserId(Guid userId, string searchTerm)
        {
            if (searchTerm == null)
            {
                return await Entities
                                .OrderByDescending(x => x.UpdatedAt)
                                .Where(x => x.UserId == userId)
                                .ToListAsync();
            } else
            {
                return await Entities
                                .OrderByDescending(x => x.UpdatedAt)
                                .Where(x => x.UserId == userId && x.Title.Contains(searchTerm))
                                .ToListAsync();
            }
        }
    }
}
