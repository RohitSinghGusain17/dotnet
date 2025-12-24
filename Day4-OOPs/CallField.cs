namespace field
{
    public class CallField
    {
        private int id;
        public int Id
        {
            set
            {
                if (value > 0)
                {
                    id=value;
                }
                else
                {
                    id=0;
                    throw new ArgumentException("id will not be less than zero");
                }
            }
        }
        public string DisplayDetatils()
        {
            return $"id is : {id}";
        }
    }
}