using System;

public class Animal { public string Name = "Animal"; }
public class Dog : Animal { public Dog() { Name = "Dog"; } }

// ✅ TODO: Students must fix variance keywords here
public interface IProducer<out T>                         // TODO: make this covariant
{
    T Produce();                                      // Produces T
}

// ✅ TODO: Students must fix variance keywords here
public interface IConsumer<in T>                         // TODO: make this contravariant
{
    void Consume(T item);                             // Consumes T
}

public class DogProducer : IProducer<Dog>
{
    public Dog Produce() => new Dog();
}

public class AnimalConsumer : IConsumer<Animal>
{
    public void Consume(Animal item)
    {
        Console.WriteLine($"Consumed: {item.Name}");
    }
}

public class Program
{
    public static void Main()
    {
        // ✅ This should compile after variance fixes:
        IProducer<Animal> p = new DogProducer();       // Covariance: Dog → Animal
        IConsumer<Dog> c = new AnimalConsumer();       // Contravariance: AnimalConsumer can consume Dog too

        Use(p, c);                                     // Execute pipeline
    }

    // ✅ TODO: Students implement only this function
    public static void Use(IProducer<Animal> producer, IConsumer<Dog> consumer)
    {
        // TODO: Produce an Animal and pass to consumer (as Dog if possible)
        Animal a = producer.Produce();
        if(a is Dog dog)
        {
            consumer.Consume(dog);
        }
        else
        {
            Console.WriteLine("Error : consumer expects Dog");
        }
    }
}