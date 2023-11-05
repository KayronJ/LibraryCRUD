using Microsoft.EntityFrameworkCore;

namespace BookStation.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book>  Books{ get; set; }
    }
}
