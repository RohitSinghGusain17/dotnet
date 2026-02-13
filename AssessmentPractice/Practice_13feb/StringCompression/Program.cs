public class Program
{
    public static void Main()
    {
        //https://leetcode.com/problems/string-compression
        char[] chars = ['a', 'a', 'a', 'b', 'b', 'b', 'c', 'c'];

        int index = 0;
        int i = 0;

        while(i<chars.Length){
            char current = chars[i];
            int count = 0;

            while(i<chars.Length && chars[i]==current){
                i++;
                count++;
            }

            chars[index++]=current;

            if(count>1){
                foreach(char c in count.ToString()){
                    chars[index++]=c;
                }
            }
        }

        Console.WriteLine(index);
        for(int j = 0; j < index; j++)
        {
            Console.WriteLine(chars[j]);
        }
    }
}