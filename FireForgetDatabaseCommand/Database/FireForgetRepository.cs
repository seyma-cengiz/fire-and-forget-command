using FireForgetDatabaseCommand.Database.Interfaces;

namespace FireForgetDatabaseCommand.Database;

public class FireForgetRepository : IFireForgetRepository
{
    private readonly IServiceScopeFactory _scopeFactory;
    public FireForgetRepository(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public void Execute(Func<IBookRepository, Task> task)
    {
        Task.Run(async () =>
        {
            try
            {
                var repo = _scopeFactory.CreateScope().ServiceProvider.GetService<IBookRepository>();
                await task(repo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        });
    }
}
