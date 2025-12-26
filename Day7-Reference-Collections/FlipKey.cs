public class FlipKey
{
    public string CleanseAndInvert(string input)
    {
        int Len = input.Length;
        if (Len < 6 || !input.All(char.IsLetter))
        {
            return "Invalid Input";
        }
        else
        {
            input = input.ToLower();
            string? NewString="";
            for(int i=0 ; i<Len; i++)
            {
                if ((int)input[i] % 2 != 0)
                {
                    NewString+=input[i];
                }
            }

            char[] array = NewString.ToCharArray();
            Array.Reverse(array);

            NewString="";

            for(int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    array[i]=Char.ToUpper(array[i]);
                }
            }

            string Final = new string(array);

            return Final;
        }
    }
}