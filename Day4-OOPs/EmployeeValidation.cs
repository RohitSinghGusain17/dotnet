namespace employee
{
    public class EmployeeValidation
    {
        private int id;
        private string? name;
        private string? rank;

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
                    throw new ArgumentException("id will not be less than zero or equal to zero");
                }
            }
        }

        public string Name
        {
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name can't be empty");
                }
                else if (value.ToLower().Contains("abc")||value.ToLower().Contains("xyz"))
                {
                    throw new ArgumentException("Enter your correct name");
                }
                else
                {
                    name=value;
                }
            }
        }

        public string Rank
        {
            set
            {
                if (value==string.Empty)
                {
                    throw new ArgumentException("Rank should be not be empty.");
                }
                else
                {
                    rank=value;
                }
            }
        }

        public string DisplayResult()
        {
            return $"id is {id}\nname is {name}\nrank is {rank}";
        }
    }
}