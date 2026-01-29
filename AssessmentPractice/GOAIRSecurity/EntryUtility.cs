using System.Text.RegularExpressions;

public class EntryUtility
{
    public bool ValidateEmployeeID(string employeeID)
    {
        bool ans;
        string pattern = @"^GOAIR/\d{4}$";
        if(Regex.IsMatch(employeeID, pattern))
        {
            ans=true;
        }
        else
        {
            ans=false;
            throw new InvalidEntryException("Invalid entry details");
            
        }

        return ans;
    }

    public bool validateDuration(int duration)
    {
        bool ans;
        if(duration >= 1 && duration <= 5)
        {
            ans =  true;
        }
        else
        {
            ans = false;
            throw new InvalidEntryException("Invalid entry details");
        }
        
        return ans;
    }
}