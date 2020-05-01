using Microsoft.EntityFrameworkCore;

namespace PROAssignment2.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Library> Library { get; set; }
    }
}
