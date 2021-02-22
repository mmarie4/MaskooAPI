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

        public async Task<ICollection<Toolbox>> GetAllByUserId(Guid userId)
        {
            return await Entities.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
