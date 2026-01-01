public static class Palindrome
{
    public static void CheckPalindrome(this string strInput)
    {
        string str = strInput.ToLower();
        #region Approach 1
        // bool flag = true;
        // char[] init = str.ToCharArray();
        // char[] rev = str.ToCharArray();
        // Array.Reverse(rev);
        // for(int i = 0; i < str.Length; i++)
        // {
        //     if (init[i] != rev[i])
        //     {
        //         flag=false;
        //         break;
        //     }
        // }
        // if (flag)
        // {
        //     Console.WriteLine(strInput+" is Palindrome");
        // }
        // else
        // {
        //     Console.WriteLine(strInput+" is not Palindrome");
        // }
        #endregion



        #region Approach 2
        // char[] revArray = str.ToCharArray();
        // Array.Reverse(revArray);
        // string revString= new string(revArray);
        // if (str == revString)
        // {
        //     Console.WriteLine(strInput+" is Palindrome");
        // }
        // else
        // {
        //     Console.WriteLine(strInput+" is not Palindrome");
        // }
        #endregion



        #region Approach 3
        bool flag=true;
        int left=0;
        int right=str.Length-1;
        while (left < right)
        {
            if (str[left] != str[right])
            {
                flag=false;
                break;
            }
            left++;
            right--;
        }
        if (flag)
        {
            Console.WriteLine(strInput+" is Palindrome");
        }
        else
        {
            Console.WriteLine(strInput+" is not Palindrome");
        }
        #endregion
    }
}