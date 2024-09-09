using Microsoft.EntityFrameworkCore;
using FormsBGone.Models;

namespace FormsBGone.Data
{
    public class FGBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public FGBContext(DbContextOptions<FGBContext> options)
            : base(options)
        {
        }

        // DbSets representing the tables
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Form> Forms { get; set; }
    }
}
