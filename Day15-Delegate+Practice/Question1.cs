public class Person
{
    public string? Name{get; set;}
    public string? Address{get; set;}
    public int Age;
}

public class PersonImplementaion
{
    public string GetName(IList<Person> person)
    {
        string ans="";
        foreach(Person i in person)
        {
            ans+=i.Name+" "+i.Address+" ";
        }
        return ans;
    }

    public double Average(IList<Person> person)
    {
        double total=0;
        double count=0;
        foreach(Person i in person)
        {
            total+=i.Age;
            count++;
        }
        return total/count;
    }

    public int Max(IList<Person>person)
    {
        int max=0;
        foreach(Person i in person)
        {
            max=Math.Max(i.Age,max);
        }
        return max;
    }
}