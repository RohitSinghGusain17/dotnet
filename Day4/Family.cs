using System;
namespace family
{
    public class Father
    {
        public virtual string InterestOn()
        {
            return "I like to play cricket";
        }
    }

    public class Son : Father
    {
        public override string InterestOn()
        {
            return "I like mobile games.";
        }
    }
}