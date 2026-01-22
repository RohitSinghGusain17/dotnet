// Interface representing a Book
public interface IBook
{
    int ID { get; set; }                // Unique ID of the book
    string? Title { get; set; }         // Title of the book
    string? Author { get; set; }        // Author name
    string? Category { get; set; }      // Category/genre of book
    int Price { get; set; }             // Price of one book
}

// Interface representing Library operations
public interface ILibrarySystem
{
    void AddBook(IBook book, int quantity);                      // Adds book with quantity
    void RemoveBook(IBook book, int quantity);                   // Removes given quantity
    int CalculateTotal();                                        // Calculates total price of all books
    List<Tuple<string, int>> CategoryTotalPrice();               // Total price per category
    List<Tuple<string, int, int>> BookInfo();                    // Title, Quantity, Price
    List<Tuple<string, string, int>> CategoryAndAuthorWithCount();// Category, Author, Count
}

// Concrete Book class
public class Book : IBook
{
    public int ID { get; set; }            // Book ID
    public string? Title { get; set; }     // Book title
    public string? Author { get; set; }    // Author name
    public string? Category { get; set; }  // Category
    public int Price { get; set; }         // Price
}

// Main library system implementation
public class LibrarySystem : ILibrarySystem
{
    private Dictionary<IBook, int> _books = new Dictionary<IBook, int>(); 
    // Stores book as key and quantity as value

    public void AddBook(IBook book, int quantity)
    {
        _books.Add(book, quantity);   // Adds new book to library
    }

    public void RemoveBook(IBook book, int quantity)
    {
        _books[book] -= quantity;     // Reduces quantity of book
    }
    
    public int CalculateTotal()
    {
        int total = 0;                // Stores total price

        foreach (var i in _books)     // Loop through all books
        {
            total += i.Key.Price * i.Value; // Price × quantity
        }

        return total;                 // Return total amount
    }

    public List<Tuple<string, int>> CategoryTotalPrice()
    {
        List<Tuple<string, int>> result = new List<Tuple<string, int>>(); 
        // Final result list

        Dictionary<string, int> dict = new Dictionary<string, int>(); 
        // Stores category and total price

        foreach (var i in _books)
        {
            if (dict.ContainsKey(i.Key.Category))
            {
                dict[i.Key.Category] += i.Key.Price * i.Value; // Add to existing
            }
            else
            {
                dict.Add(i.Key.Category, i.Key.Price * i.Value); // New category
            }
        }

        foreach (var i in dict)
        {
            result.Add(new Tuple<string, int>(i.Key, i.Value)); // Add to result
        }

        return result;   // Return category totals
    }

    public List<Tuple<string, int, int>> BookInfo()
    {
        List<Tuple<string, int, int>> result = new List<Tuple<string, int, int>>(); 
        // Stores book info

        foreach (var i in _books)
        {
            result.Add(new Tuple<string, int, int>(i.Key.Title, i.Value, i.Key.Price)); 
            // Title, Quantity, Price
        }

        return result;   // Return book info list
    }

    public List<Tuple<string, string, int>> CategoryAndAuthorWithCount()
    {
        List<Tuple<string, string, int>> ordered = new List<Tuple<string, string, int>>(); 
        // Final output list

        Dictionary<string, List<IBook>> categoryWise = new Dictionary<string, List<IBook>>(); 
        // Groups books by category

        foreach (var i in _books)
        {
            if (!categoryWise.ContainsKey(i.Key.Category))
                categoryWise[i.Key.Category] = new List<IBook>(); // New category

            categoryWise[i.Key.Category].Add(i.Key); // Add book to category
        }

        foreach (var i in categoryWise)
        {
            string cata = i.Key;  // Current category

            Dictionary<string, int> authorWise = new Dictionary<string, int>(); 
            // Stores author and count

            foreach (var j in i.Value)
            {
                if (!authorWise.ContainsKey(j.Author))
                    authorWise[j.Author] = 0; // New author

                authorWise[j.Author] += _books[j]; // Add quantity
            }

            foreach (var j in authorWise)
            {
                ordered.Add(new Tuple<string, string, int>(cata, j.Key, j.Value)); 
                // Category, Author, Count
            }
        }

        return ordered;  // Return final list
    }
}
