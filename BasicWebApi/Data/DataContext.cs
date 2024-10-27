using BasicWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<SuperHEro> SuperHeroes { get; set; }
    }
}
