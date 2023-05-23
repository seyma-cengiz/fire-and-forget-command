using FireForgetDatabaseCommand.Entities;

namespace FireForgetDatabaseCommand.Models;

public class BookModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int PublicationYear { get; set; }
    public string Author { get; set; }
    public ICollection<BookAudit> BookAudits { get; set; }
}
