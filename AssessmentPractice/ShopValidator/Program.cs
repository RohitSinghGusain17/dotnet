public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of gadget entries");
        int number = int.Parse(Console.ReadLine()!);
        GadgetValidatorUtil gadgetValidatorUtil = new GadgetValidatorUtil();

        for(int i = 1; i <= number; i++)
        {
            Console.WriteLine($"Enter gadget {i} details");
            string input = Console.ReadLine()!;
            string[] gadget = input.Split(":");
            try
            {
                var result1 = gadgetValidatorUtil.validateGadgetID(gadget[0]);
                var result2 = gadgetValidatorUtil.validateWarrantyPeriod(int.Parse(gadget[2]));
                if(result1 && result2)
                {
                    Console.WriteLine("Warranty accepted, stock updated");
                }
            }
            catch(InvalidGadgetException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}