using System.Runtime.CompilerServices;

public class ThreadExample
{
    public static async Task AsyncMethod()
    {
        Console.WriteLine("Task started");
        await Task.Delay(3000);
        System.Console.WriteLine("Task completed after 3 second");
    }
    public static async Task<string> FetchDataAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(url);
            return response;
        }
    }
    public static async Task CallMethod()
    {
        string result = await FetchDataAsync("https://jsonplaceholder.typicode.com/todos/1");
        System.Console.WriteLine(result);
    }
}