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

        public async Task<ICollection<Note>> GetAllByUserId(Guid userId)
        {
            return await Entities.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
