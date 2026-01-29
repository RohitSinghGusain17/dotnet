// Main namespace representing the Library System domain
namespace LibrarySystem
{
    // Enum defining different types of users in the library
    public enum UserRole
    {
        Admin,
        Librarian,
        Member
    }

    // Enum defining possible states of a library item
    public enum ItemStatus
    {
        Available,
        Borrowed,
        Reserved,
        Lost
    }

    // Abstract base class representing a generic library item
    public abstract class LibraryItem
    {
        public string? Title;     // Title of the item
        public string? Author;    // Author of the item
        public int ItemID;        // Unique ID of the item

        // Abstract method to display item details
        public abstract void DisplayItem();

        // Abstract method to calculate late fee based on days
        public abstract void CalculateLateFee(int Days);
    }

    // Interface for reservable items
    interface IReservable
    {
        void ReserveItem();   // Reserves the library item
    }

    // Interface for sending notifications
    interface INotifiable
    {
        void AcceptMessage(); // Sends notification message
    }

    // Namespace for different types of library items
    namespace Items
    {
        // Book class inheriting LibraryItem and implementing multiple interfaces
        class Book : LibraryItem, IReservable, INotifiable
        {
            // Displays book details
            public override void DisplayItem()
            {
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Author: " + Author);
                Console.WriteLine("ItemID: " + ItemID);
            }

            // Calculates late fee for book (₹1 per day)
            public override void CalculateLateFee(int Days)
            {
                Console.WriteLine("Late fees: " + 1 * Days);
            }

            // Explicit interface implementation for reservation
            void IReservable.ReserveItem()
            {
                Console.WriteLine("Reservation Success");
            }

            // Explicit interface implementation for notifications
            void INotifiable.AcceptMessage()
            {
                Console.WriteLine("Notification message sent");
            }
        }

        // Magazine class inheriting LibraryItem
        class Magazine : LibraryItem
        {
            // Displays magazine details
            public override void DisplayItem()
            {
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Author: " + Author);
                Console.WriteLine("ItemID: " + ItemID);
            }

            // Calculates late fee for magazine (₹0.5 per day)
            public override void CalculateLateFee(int Days)
            {
                Console.WriteLine("Late fees: " + 0.5 * Days);
            }
        }
    }

    // Namespace for library users
    namespace Users
    {
        // Member class representing a library user
        public class Member
        {
            public string? Name;   // Name of the member
            public UserRole Role;  // Role of the user
        }
    }

    // Partial class used for library analytics
    public partial class LibraryAnalytics
    {
        public static int TotalBorrowedItems; // Static counter for borrowed items

        // Displays analytics information
        public static void DisplayAnalytics()
        {
            Console.WriteLine($"Total Items Borrowed: {TotalBorrowedItems}");
        }
    }
}

// Main program execution starts here
public class Program
{
    public static void Main(string[] args)
    {
        #region Task1
        // Creating and using Book object
        LibrarySystem.Items.Book b = new LibrarySystem.Items.Book();
        b.Title = "ABCBook";
        b.Author = "XYZ";
        b.ItemID = 1;
        b.DisplayItem();
        b.CalculateLateFee(3);

        // Creating and using Magazine object
        LibrarySystem.Items.Magazine m = new LibrarySystem.Items.Magazine();
        m.Title = "ABCMagazine";
        m.Author = "XYZ";
        m.ItemID = 1;
        m.DisplayItem();
        m.CalculateLateFee(3);
        #endregion

        #region Task2 and Task4
        // Interface-based reference demonstrating explicit interface implementation
        LibrarySystem.IReservable reservable = b;
        LibrarySystem.INotifiable notifiable = b;
        reservable.ReserveItem();
        notifiable.AcceptMessage();
        #endregion

        #region Task3
        // Demonstrating runtime polymorphism using base class reference
        List<LibrarySystem.LibraryItem> items = new List<LibrarySystem.LibraryItem>
        {
            b,
            m
        };

        foreach (LibrarySystem.LibraryItem item in items)
        {
            item.DisplayItem();
            Console.WriteLine();
        }

        // Explanation of runtime polymorphism
        Console.WriteLine("Explanation: The method executed depends on the object type at runtime, not the reference type.\n");
        #endregion

        #region Task6
        // Using static members of partial class
        LibrarySystem.LibraryAnalytics.TotalBorrowedItems += 5;
        LibrarySystem.LibraryAnalytics.DisplayAnalytics();
        #endregion

        #region Task7
        // Creating a member and assigning enum values
        LibrarySystem.Users.Member member = new LibrarySystem.Users.Member
        {
            Name = "Rohit",
            Role = LibrarySystem.UserRole.Member
        };

        // Demonstrating enum usage for item status
        LibrarySystem.ItemStatus status = LibrarySystem.ItemStatus.Borrowed;
        Console.WriteLine("User Role: " + member.Role);
        Console.WriteLine("Item Status: " + status);
        #endregion
    }
}
