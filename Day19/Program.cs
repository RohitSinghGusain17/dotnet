using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        // //Question 1 Find Items
        // FindItems.itemDetails.Add("Abc",4);
        // FindItems.itemDetails.Add("Xyz",2);
        // FindItems.itemDetails.Add("PQR",2);
        // FindItems findItems = new FindItems();
        // var data = findItems.FindItemDetails(2);
        // foreach (var item in data)
        // {
        //     Console.WriteLine(item.Key+" "+item.Value);
        // }
        // Console.WriteLine("----------------------------------");
        // var listData = findItems.FindMinandMaxSoldItems();
        // foreach(var item in listData)
        // {
        //     Console.WriteLine(item);
        // }
        // Console.WriteLine("----------------------------------");
        // var dictdata = findItems.SortByCount();
        // foreach (var item in dictdata)
        // {
        //     Console.WriteLine(item.Key+" "+item.Value);
        // }


        // //Question 2 MovieStock
        // string genre = "Scifi";
        // MovieStock movieStock = new MovieStock();
        // movieStock.AddMovie("ABC,mohan,Scifi,3");
        // movieStock.AddMovie("def,rohan,Action,4");
        // movieStock.AddMovie("pqr,sohan,Adventure,2");
        // Console.WriteLine("----------------------------");
        // var movieListGenre = movieStock.ViewMoviesByGenre(genre);
        // foreach (var item in movieListGenre)
        // {
        //     System.Console.WriteLine(item.Title + " "+item.Artist+" "+item.Genre);
        // }
        // Console.WriteLine("----------------------------");
        // var movieListRating = movieStock.ViewMoviesByRatings();
        // foreach(var item in movieListRating)
        // {
        //     System.Console.WriteLine(item.Title + " "+item.Artist+" "+item.Genre);
        // }


        // //Question 3 CalculateNumbers
        // CalculateNumbers calculateNumbers = new CalculateNumbers();
        // calculateNumbers.AddNumbers(64);
        // calculateNumbers.AddNumbers(50);
        // calculateNumbers.AddNumbers(60);
        // Console.WriteLine(calculateNumbers.GetGradeScored(7));
        // Console.WriteLine(calculateNumbers.GetGPAScored());


        //Question 4 Yoga Mediation
        // MeditationCenter meditationCenter = new MeditationCenter();
        // meditationCenter.AddYogaMember(1,23,56.2,1.23,"Weight Loss");
        // meditationCenter.AddYogaMember(2,25,52.2,1.23,"Weight Gain");
        // meditationCenter.AddYogaMember(3,28,56.2,1.23,"Weight Loss");
        // Console.WriteLine(meditationCenter.CalculateBMI(2));
        // System.Console.WriteLine(meditationCenter.CalculateYogaFee(3));


        // //Question 5 EcommerceShop
        // try
        // {
        //     EcommerceShop ecommerceShop = new EcommerceShop();
        //      var ans = ecommerceShop.MakePayment("Emily",91,67);
        //     if (ans.WalletBalance < ans.TotalPurchaseAmount)
        //     {
        //         throw new InsufficientWalletBalanceException("Insufficient balance in your digital wallet.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Done");
        //     }
        // }
        // catch (InsufficientWalletBalanceException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }


        // //Question 6 UserAuthentication
        // try
        // {
        //     User user = new User();
        //     var ans = user.ValidatePassword("rohit","123","123");
        //     if (ans.Name != "")
        //     {
        //         Console.WriteLine("Registered Successfully");
        //     }
        // }
        // catch (PasswordMismatchException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }


        // // Question 7 Construction Estimate
        // EstimateDetails estimateDetails = new EstimateDetails();
        // try
        // {
        //     estimateDetails.ValidateConstructionEstimate(89,45);
        //     Console.WriteLine("Success");
        // }
        // catch(ConstructionEstimateException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }


        // //Question 8 UserVerification
        // try
        // {
        //     UserVerification userVerification = new UserVerification();
        //     userVerification.ValidatePhoneNumbner("Rohit","7823456734");
        //     Console.WriteLine("Success");
        // }
        // catch(InvalidPhoneNumberException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }


        
    }
}