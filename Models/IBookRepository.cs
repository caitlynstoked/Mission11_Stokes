namespace Mission11Stokes.Models;

public interface IBookRepository
{
    public IQueryable<Book> Books { get; }
}