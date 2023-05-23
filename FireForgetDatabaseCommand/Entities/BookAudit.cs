namespace FireForgetDatabaseCommand.Entities;

public class BookAudit
{
    public int Id { get; set; }
    public Guid BookId { get; set; }
    public DateTime Date { get; set; }
    public string Action { get; set; }
}