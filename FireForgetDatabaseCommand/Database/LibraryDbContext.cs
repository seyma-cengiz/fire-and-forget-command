using FireForgetDatabaseCommand.Entities;
using Microsoft.EntityFrameworkCore;

namespace FireForgetDatabaseCommand.Database;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<BookAudit> BookAudits { get; set; }
}
