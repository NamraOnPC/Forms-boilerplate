using Microsoft.EntityFrameworkCore;

namespace PROAssignment2.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
           : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}
