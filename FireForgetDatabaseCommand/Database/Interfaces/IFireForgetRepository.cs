namespace FireForgetDatabaseCommand.Database.Interfaces;

public interface IFireForgetRepository
{
    void Execute(Func<IBookRepository, Task> task);
}
