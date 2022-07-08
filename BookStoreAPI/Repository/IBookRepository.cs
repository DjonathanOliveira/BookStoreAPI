using BookStoreAPI.Model;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        Task<Book> Create(Book book);
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int id);
        Task Update(Book book);
        Task Delete(int id);

    }
}
