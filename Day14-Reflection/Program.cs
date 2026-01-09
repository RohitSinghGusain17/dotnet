public class Program
    {
        static void Main(string[] args)
        {
           DepartmentClass obj = new DepartmentClass();
           var props = obj.GetType().GetFields(BindingFlags.NonPublic|BindingFlags.Instance).ToList();

           foreach(var prop in props)
            {
                Console.WriteLine(prop.Name);
            }
            Console.ReadLine();
        }
    }