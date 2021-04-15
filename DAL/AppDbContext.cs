using System.Diagnostics.CodeAnalysis;
using DAL.Entities.Diaries;
using DAL.Entities.Notes;
using DAL.Entities.Tools;
using DAL.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNull] DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Toolbox> Toolboxes { get; set; }
        public DbSet<Tool> Tools { get; set; }

    }
}
