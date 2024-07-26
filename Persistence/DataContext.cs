using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        // "options" allow parse an "options" to it e.g. connection strings.
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        // represent the table in DB
        public DbSet<Activity> Activities { get; set; }
    }
}