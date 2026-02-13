public class Program
{
    public static void Main()
    {
        //Undo Feature – Text Editor
        //TYPE word appends a word with a space.
        // UNDO removes the last typed word.
        // If nothing to undo, ignore UNDO.
        List<string> ops = new List<string> {"TYPE Hello","TYPE World","UNDO","TYPE CSharp"};
        Stack<string> st = new Stack<string>();
        string finalText = "";

        foreach(var i in ops)
        {
            string[] splitOps = i.Split(" ");
            if (splitOps[0].Equals("TYPE"))
            {
                st.Push(splitOps[1]);
            }
            else
            {
                st.Pop();
            }
        }
        

        finalText = string.Join(" ", st.Reverse());
        Console.WriteLine(finalText);
    }
}