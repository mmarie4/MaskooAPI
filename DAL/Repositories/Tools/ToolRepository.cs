using DAL.Entities.Tools;

namespace DAL.Repositories.Tools
{
    public class ToolRepository : Repository<Tool>, IToolRepository
    {
        public ToolRepository(AppDbContext context) : base(context)
        {
        }
    }
}
