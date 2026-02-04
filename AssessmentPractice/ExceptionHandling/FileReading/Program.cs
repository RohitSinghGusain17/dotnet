using System;
using System.IO;

public class FileReader
{
    public static void Main(string[] args)
    {
        string filePath = "data.txt";

        try
        {
            // 4. Ensure resource is closed properly
            using(StreamReader s = new StreamReader(filePath))
            {
                // 1. Read file content
                string str = s.ReadToEnd();
                Console.WriteLine("File content : "+str);
            }
        }
        // 2. Handle FileNotFoundException
        catch(FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        // 3. Handle UnauthorizedAccessException
        catch(UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}