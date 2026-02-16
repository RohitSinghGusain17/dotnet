public class Book
{
    public string? ISBN { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
    public bool IsAvailable { get; set; }
}

// Generic catalog class
public class Catalog<T> where T : Book
{
    private List<T> _items = new List<T>();
    private SortedDictionary<string, List<T>> _genreIndex = new SortedDictionary<string, List<T>>();
    
    // Add item with genre indexing
    public bool AddItem(T item)
    {
        bool Added = false;
        if (_items.Contains(item))
        {
            Console.WriteLine("Item Already Exist");
        }
        else
        {
            _items.Add(item);
            if (_genreIndex.ContainsKey(item.Genre!))
            {
                _genreIndex[item.Genre!].Add(item);
                Added=true;
            }
            else
            {
                _genreIndex[item.Genre!]=new List<T> {item};
            }
        }

        return Added;
    }
    
    // Get books by genre using indexer
    public List<T> this[string genre]
    {
        get
        {
            return _genreIndex.Where(x=>x.Key==genre).SelectMany(x=>x.Value).ToList();
        }
    }
    
    // Find books using LINQ and lambda expressions
    public IEnumerable<T> FindBooks(Func<T, bool> predicate)
    {
        var result = _items.Where(predicate);
        return result;
    }
}

public class Program
{
    public static void Main()
    {
        Catalog<Book> library = new Catalog<Book>();

    Book book1 = new Book 
    { 
        ISBN = "978-3-16-148410-0", 
        Title = "C# Programming", 
        Author = "John Sharp", 
        Genre = "Programming" 
    };

    library.AddItem(book1);

    var programmingBooks = library["Programming"];
    Console.WriteLine(programmingBooks.Count); // Should output: 1

    var johnsBooks = library.FindBooks(b => b.Author!.Contains("John"));
    Console.WriteLine(johnsBooks.Count()); // Should output: 1
    }
}