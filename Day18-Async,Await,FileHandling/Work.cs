public class Work<TKey,TValue> where TKey : notnull
    {
        public static Dictionary<TKey,TValue> dict = new Dictionary<TKey, TValue>();
        public void Add(TKey k, TValue v)
        {
            dict.Add(k,v);
        }
        public void show()
        {
            foreach(var i in dict)
            {
                Console.WriteLine(i.Key+" "+i.Value);
            }
        }
    }