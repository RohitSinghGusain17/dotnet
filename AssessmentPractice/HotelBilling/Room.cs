interface IRoom
{
    public double calculateTotalBill(int nightsStayed, int joiningYear);
    public int calculateMembershipYears(int joiningYear);   
}

public class HotelRoom : IRoom
{
    public string roomType{get; set;}
    public double ratePerNight{get; set;}
    public string guestName{get; set;}

    public HotelRoom(string roomType, double ratePerNight, string guestName)
    {
        this.roomType=roomType;
        this.ratePerNight=ratePerNight;
        this.guestName=guestName;
    }

    public int calculateMembershipYears(int joiningYear)
    {
        int currentYear=2026;
        int ansYear = currentYear-joiningYear;
        return ansYear;
    }

    public double calculateTotalBill(int nightsStayed, int joiningYear){
        double total = 0;
        total = nightsStayed*ratePerNight;
        int year = calculateMembershipYears(joiningYear);

        if (year > 3)
        {
            total-=total*0.10;
        }

        return Math.Round(total);
    }
}