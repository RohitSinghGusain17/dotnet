 public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            char[] chars= str.ToCharArray();
            int count = 1;
            foreach (var item in chars)
            {
                if (item.Equals(' '))
                    count++;
            }

            return count;
        }
    }