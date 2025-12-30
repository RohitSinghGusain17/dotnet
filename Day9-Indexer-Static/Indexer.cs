using System.Windows.Markup;

class Indexer
{
    private string[] Values = new string[3];

    public string this[int index]{
        get
        {
            return Values[index];
        }
        set
        {
            Values[index] = value;
        }
    }
}