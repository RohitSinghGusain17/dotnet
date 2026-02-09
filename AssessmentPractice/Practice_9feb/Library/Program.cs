public class Author
{
    public string? AuthorName{get; set;}
    public string? Country{get; set;}
}

public class Book : Author
{
    public string? Title{get; set;}
    public double Price{get; set;}
    public Author? author;

    public Book(string title, double price, Author auth)
    {
        Title=title;
        Price=price;
        author=auth;
    }

    public void getBookDetails()
    {
        Console.WriteLine($"Book Details : {Title}, {author!.AuthorName}, {author.Country}, {Price}");
    }
}

public class Program
{
    public static void Main()
    {
        Book book1 = new Book("qwerty",300,new Author{AuthorName="rohit",Country="ind"});
        book1.getBookDetails();
        Book book2 = new Book("mnop",200,new Author{AuthorName="rohit",Country="ind"});
        book2.getBookDetails();
    }
}