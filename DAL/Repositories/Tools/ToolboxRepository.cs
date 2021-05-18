using DAL.Entities.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.Tools
{
    public class ToolboxRepository : Repository<Toolbox>, IToolboxRepository
    {
        public ToolboxRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Toolbox>> GetAllByUserId(Guid userId, string searchTerm)
        {
            if (searchTerm == null)
            {
                return await Entities
                                .OrderByDescending(x => x.UpdatedAt)
                                .Where(x => x.UserId == userId)
                                .Include(x => x.Tools)
                                .ToListAsync();
            }
            else
            {
                return await Entities
                                .OrderByDescending(x => x.UpdatedAt)
                                .Where(x => x.UserId == userId && x.Label.ToLower().Contains(searchTerm.ToLower()))
                                .Include(x => x.Tools)
                                .ToListAsync();
            }
        }

        public override async Task<Toolbox> GetByIdAsync(Guid id)
        {
            return await Entities
                            .Include(x => x.Tools)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
