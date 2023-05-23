using FireForgetDatabaseCommand.Entities;
using FireForgetDatabaseCommand.Models;

namespace FireForgetDatabaseCommand.Database.Interfaces;

public interface IBookRepository
{
    BookModel GetBook(Guid id);
    Task AddBookAsync(Book entity);
    Task AddBookAuditAsync(BookAudit entity);
}
