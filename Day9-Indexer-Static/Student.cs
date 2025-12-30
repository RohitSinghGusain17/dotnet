//Create a student with public properties of rno, name, private field of address, indexers for books he have.
class Student
{
    public int Rno;
    public string? Name;
    private string? Address;
    // private string[] books = new string[3];
    private List<string> books = new List<string>();

    public Student(int RnoIn, string NameIn, string AddressIn)
    {
        Rno=RnoIn;
        Name=NameIn;
        Address=AddressIn;
    }

    public string this[int index]
    {
        get
        {
            return books[index];
        }
        set
        {
            if (index < books.Count)
            {
                books[index]=value;
            }
            else
            {
                books.Add(value);
            }
        }
    }

    public string? GetAddress()
    {
        return Address;
    }
}