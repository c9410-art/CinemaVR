using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CinemaVR.Api.Data
{
    public class CinemaContextFactory : IDesignTimeDbContextFactory<CinemaContext>
    {
        public CinemaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();

            // Підключення до SQLite
            optionsBuilder.UseSqlite("Data Source=Cinema.db");

            return new CinemaContext(optionsBuilder.Options);
        }
    }
}
