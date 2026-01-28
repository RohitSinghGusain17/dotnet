public class Apartment
{
    private Dictionary<string, double> apartmentDetails = new Dictionary<string, double>();

    public void addApartmentDetails(string apartmentNumber, double rent)
    {
        apartmentDetails[apartmentNumber]=rent;
    }

    public double findTotalRentOfApartmetsInTheGivenRange(double minimum, double maximum)
    {
        double result=0;
        result = apartmentDetails.Where(x=>x.Value>=minimum && x.Value<=maximum).Sum(x=>x.Value);
        return result;
    }
}