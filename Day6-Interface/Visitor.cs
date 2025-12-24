namespace visit
{
    interface Iveg
    {
        void EatVeg();   
        void Taste(); 
    }
    interface INonVeg
    {
        void EatNonVeg();
        void Taste();
    }
    public class Visitor : Iveg, INonVeg
    {
        public void EatVeg()
        {
            Console.WriteLine("Eat Veg");
        }
         void Iveg.Taste()  //Explicit Implementation(No public)
        {
            Console.WriteLine("Taste is good.");
        }
         void INonVeg.Taste()
        {
            Console.WriteLine("Taste is good.");
        }
        public void EatNonVeg()
        {
            Console.WriteLine("Eat NonVeg");
        }
    }
}