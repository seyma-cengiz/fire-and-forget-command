using FireForgetDatabaseCommand.Database.Interfaces;
using FireForgetDatabaseCommand.Entities;
using FireForgetDatabaseCommand.Models;
using Microsoft.EntityFrameworkCore;

namespace FireForgetDatabaseCommand.Database;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;
    public BookRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public BookModel GetBook(Guid id)
    {
        var book = _context.Books.Find(id);
        var audits = _context.BookAudits.Where(t => t.BookId == id).ToList();
        var model = new BookModel
        {
            Id = book.Id,
            Author = book.Author,
            Description = book.Description,
            PublicationYear = book.PublicationYear,
            Title = book.Title,
            BookAudits = audits
        };
        return model;
    }

    public async Task AddBookAsync(Book entity)
    {
        _context.Books.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddBookAuditAsync(BookAudit entity)
    {
        _context.BookAudits.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<BookAudit>> GetBookAudits(Guid bookId)
    {
        return await _context.BookAudits.Where(t => t.BookId == bookId).ToListAsync();
    }
}
