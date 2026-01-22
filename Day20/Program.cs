namespace Day20
{
    public class Program
    {
        // public ref struct TempBuffer
        // {
        //     public void Dispose()
        //     {
        //         // cleanup logic (concept)
        //         Console.WriteLine("Success");
        //     }
        // }

        // public static void UseBuffer()
        // {
        //     // C# 8.0: using works with ref struct (pattern-based)
        //     using var buf = new TempBuffer();
        //     // work with buf
        // }

        public static int result { get; set; }
        static void Main(string[] args)
        {
            // string nullString= (string)null;
            // Console.WriteLine(nullString is string);


            // //Question 1 Movie Library
            // FilmLibrary filmLibrary = new FilmLibrary();
            // filmLibrary.AddFilm(new Film{Title="abc", Director="pqr", Year=2022});
            // filmLibrary.AddFilm(new Film{Title="Hello world", Director="xyz", Year=2024});
            // Console.WriteLine("--------------------All Films-----------------------------");
            // var ansFilms = filmLibrary.GetFilms();
            // foreach(var i in ansFilms)
            // {
            //     Console.WriteLine(i.Title+" "+i.Director);
            // }
            // Console.WriteLine("-------------------------Search Film------------------------");
            // var ansSearch = filmLibrary.SearchFilms("world");
            // foreach(var i in ansSearch)
            // {
            //     Console.WriteLine(i.Title+" "+i.Director);
            // }
            // Console.WriteLine("-----------------------Total--------------------------");
            // Console.WriteLine("Total film Count: "+filmLibrary.GetTotalFilmCount());
            // Console.WriteLine("------------------------Remove-------------------------");
            // filmLibrary.RemoveFilm("abc");



            // //Question 2 Real Estate listing Management
            // RealEstateApp realEstateApp = new RealEstateApp();
            // realEstateApp.AddListing(new RealEstateListing{ID=1, Price=200, Location="India", Title="ABC", Description="qwerty"});
            // realEstateApp.AddListing(new RealEstateListing{ID=2, Price=450, Location="US", Title="AvC", Description="jkl;"});
            // realEstateApp.AddListing(new RealEstateListing{ID=3, Price=220, Location="India", Title="ABc", Description="asdf"});
            // Console.WriteLine("------------------------Update-------------------------");
            // realEstateApp.UpdateListing(new RealEstateListing{ID=2, Price=4500, Location="US", Title="AC", Description="jkl;"});
            // Console.WriteLine("------------------------ALL listings-------------------------");
            // var ansListings = realEstateApp.GetListings();
            // foreach(var i in ansListings)
            // {
            //     Console.WriteLine(i.ID+" "+i.Title+" "+i.Description+" "+i.Price);
            // }
            // Console.WriteLine("------------------------listings by location-------------------------");
            // var ansListingsLocation = realEstateApp.GetListingsByLocation("US");
            // foreach(var i in ansListingsLocation)
            // {
            //     Console.WriteLine(i.ID+" "+i.Title+" "+i.Description+" "+i.Price);
            // }
            // Console.WriteLine("------------------------listings by Price Range-------------------------");
            // var ansListingsRange = realEstateApp.GetListingsByPriceRange(200,300);
            // foreach(var i in ansListingsRange)
            // {
            //     Console.WriteLine(i.ID+" "+i.Title+" "+i.Description+" "+i.Price);
            // }
            // Console.WriteLine("------------------------Remove listing by id-------------------------");
            // realEstateApp.RemoveListing(3);



            // // basic Question answer
            // List<int> list = new List<int>();
            // Console.Write("Enter the numbers you want to add: ");
            // int n = int.Parse(Console.ReadLine()!);
            // for(int i = 0; i < n; i++)
            // {
            //     int num = int.Parse(Console.ReadLine()!);
            //     list.Add(num);
            // }
            // Console.WriteLine("Output: ");
            // var evenNum = from i in list where i%2==0 select i;
            // foreach(var item in evenNum)
            // {
            //     Console.WriteLine(item);
            // }



            // // basic question answer
            // List<Employee> list = new List<Employee>();
            // list.Add(new Employee{ID=1, Name="Rohit"});
            // list.Add(new Employee{ID=2, Name="Sumit"});
            // int id=2;
            // var emp = list.FirstOrDefault(x => x.ID == id);
            // Console.WriteLine(emp.ID+" "+emp.Name);


            // // ref struct
            // UseBuffer();



            //Question 3 Library Management System
            LibrarySystem librarySystem = new LibrarySystem();

            // Add books to library
            librarySystem.AddBook(new Book
            {
                ID = 1,
                Title = "PeterPan",
                Author = "JamesMatheewBarrie",
                Category = "KiDsClassics",
                Price = 193,
            }, 11);

            librarySystem.AddBook(new Book
            {
                ID = 2,
                Title = "tu meri m tera",
                Author = "FrankBaum",
                Category = "Man",
                Price = 394,
            }, 3);

            librarySystem.AddBook(new Book
            {
                ID = 1,
                Title = "Jai shree ram",
                Author = "JamesMatheewBarrie",
                Category = "KidsClassics",
                Price = 193,
            }, 11);

            librarySystem.AddBook(new Book
            {
                ID = 2,
                Title = "Pappu pass",
                Author = "FrankBaum",
                Category = "Man",
                Price = 394,
            }, 3);

            // Fetch different reports
            var bookInfo = librarySystem.BookInfo();
            var authorWise = librarySystem.CategoryAndAuthorWithCount();
            int total = librarySystem.CalculateTotal();
            var catagoryWise = librarySystem.CategoryTotalPrice();

            // Display book information
            System.Console.WriteLine("Books:");
            bookInfo.ForEach(x => System.Console.WriteLine($" {x.Item1} - {x.Item2} - {x.Item3}"));

            System.Console.WriteLine();
            System.Console.WriteLine("Catagory -> AuthWise: ");
            authorWise.ForEach(x => System.Console.WriteLine($" {x.Item1} - {x.Item2} - {x.Item3}"));

            System.Console.WriteLine();
            System.Console.WriteLine("Total:-" + total);

            System.Console.WriteLine("Catagory Wise:");
            catagoryWise.ForEach(x => System.Console.WriteLine($" {x.Item1} - {x.Item2}  "));
        }
    }
}