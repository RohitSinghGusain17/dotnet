using LibraryApp.Models;

namespace LibraryApp.Repositories
{
    public class MemoryBookRepository : IBookRepository
    {
        private List<Book> books;

        public MemoryBookRepository()
        {
            books = new List<Book>()
            {
                new Book { BookId = 1, Title = "abc", Author = "pqr", Price = 500 },
                new Book { BookId = 2, Title = "xyz", Author = "pqr", Price = 650 },
                new Book { BookId = 3, Title = "mno", Author = "pqr", Price = 700 }
            };
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(b => b.BookId == id);
        }

        public void AddBook(Book book)
        {
            book.BookId = books.Max(b => b.BookId) + 1;
            books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.BookId == id);
            if (book != null)
            {
                books.Remove(book);
            }
        }
    }
}