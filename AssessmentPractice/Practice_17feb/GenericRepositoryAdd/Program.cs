using System;                                     // Console
using System.Collections.Generic;                 // List<T>

public class Program
{
    public static void Main()
    {
        var intRepo = new SimpleRepo<int>();       // Repo for int
        intRepo.Add(10);
        intRepo.Add(20);

        Console.WriteLine(string.Join(",", intRepo.GetAll())); // Expected: 10,20

        var nameRepo = new SimpleRepo<string>();   // Repo for string
        nameRepo.Add("Asha");
        nameRepo.Add("Vikram");

        Console.WriteLine(string.Join(",", nameRepo.GetAll())); // Expected: Asha,Vikram
    }
}

public class SimpleRepo<T>
{
    private readonly List<T> _items = new();       // In-memory storage

    // ✅ TODO: Students implement this
    public void Add(T item)
    {
        _items.Add(item);
    }

    // ✅ TODO: Students implement this
    public IReadOnlyList<T> GetAll()
    {
        // TODO: Return all items as read-only list
        return _items.AsReadOnly();
    }
}