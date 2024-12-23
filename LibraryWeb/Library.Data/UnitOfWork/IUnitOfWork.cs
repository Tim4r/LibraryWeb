using Library.Data.Repository.Interfaces;

namespace Library.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IBookRepository Books { get; }
    IAuthorRepository Authors { get; }
    IGenreRepository Genres { get; }

    Task<int> CompleteAsync();
}
