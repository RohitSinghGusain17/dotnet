using LibraryApp.Models;

namespace LibraryApp.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();

        Book GetBookById(int id);

        void AddBook(Book book);

        void DeleteBook(int id);
    }
}