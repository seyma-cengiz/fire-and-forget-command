using FireForgetDatabaseCommand.Database.Interfaces;
using FireForgetDatabaseCommand.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FireForgetDatabaseCommand.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly IFireForgetRepository _fireForgetRepository;
    public BookController(IBookRepository bookRepository, IFireForgetRepository fireForgetRepository)
    {
        _bookRepository = bookRepository;
        _fireForgetRepository = fireForgetRepository;

    }
    [HttpGet]
    public async Task<IActionResult> Get(Guid id)
    {
        var book = _bookRepository.GetBook(id);
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(Book model)
    {

        await _bookRepository.AddBookAsync(model);

        var audit = new BookAudit
        {
            BookId = model.Id,
            Date = DateTime.Now,
            Action = "New book added."
        };

        _fireForgetRepository.Execute(async repo =>
        {
            await repo.AddBookAuditAsync(audit);
        });

        //_ = Task.Run(async () =>
        //{
        //    try
        //    {
        //        var audit = new BookAudit
        //        {
        //            BookId = model.Id,
        //            Date = DateTime.Now,
        //            Action = "New book added."
        //        };
        //        var repo = serviceScopeFactory.CreateScope().ServiceProvider.GetService<IBookRepository>();
        //        await repo.AddBookAuditAsync(audit);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //});

        return Ok(model);
    }
}
