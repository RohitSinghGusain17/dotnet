public class Book
{
    public string? Title{get; set;}
    public string? Author{get; set;}
    public string? Genre{get; set;}
    public int PublicationYear;
}

public class LibraryUtility
{
    public List<Book> BookList = new List<Book>();
    public void AddBook(string title, string author, string genre, int year)
    {
        BookList.Add(new Book{Title=title, Author= author, Genre=genre, PublicationYear=year});
    }

    public SortedDictionary<string, List<Book>> GroupBooksByGenre()
    {
        SortedDictionary<string, List<Book>> result =new SortedDictionary<string, List<Book>>();
        var ex = BookList.GroupBy(x=>x.Genre);
        foreach(var i in ex)
        {
            result[i.Key!]=i.ToList();
        }

        return result;
    }

    public List<Book> GetBooksByAuthor(string author)
    {
        return BookList.Where(x=>x.Author==author).ToList();
    }

    public int GetTotalBooksCount()
    {
        return BookList.Count;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        LibraryUtility library = new LibraryUtility();

        // Add books
        library.AddBook("The Hobbit", "J.R.R. Tolkien", "Fantasy", 1937);
        library.AddBook("1984", "George Orwell", "Dystopian", 1949);
        library.AddBook("Animal Farm", "George Orwell", "Dystopian", 1945);
        library.AddBook("Harry Potter", "J.K. Rowling", "Fantasy", 1997);

        // Display total books
        Console.WriteLine("Total Books: " + library.GetTotalBooksCount());
        Console.WriteLine();

        // Group books by genre
        Console.WriteLine("Books Grouped by Genre:");
        var groupedBooks = library.GroupBooksByGenre();

        foreach (var genre in groupedBooks)
        {
            Console.WriteLine("Genre: " + genre.Key);
            foreach (var book in genre.Value)
            {
                Console.WriteLine($"  {book.Title} by {book.Author} ({book.PublicationYear})");
            }
            Console.WriteLine();
        }

        // Get books by author
        Console.WriteLine("Books by George Orwell:");
        var authorBooks = library.GetBooksByAuthor("George Orwell");

        foreach (var book in authorBooks)
        {
            Console.WriteLine($"{book.Title} ({book.PublicationYear})");
        }
    }
}