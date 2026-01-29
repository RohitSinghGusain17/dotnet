using System.Text.RegularExpressions;

public class GadgetValidatorUtil
{
    public bool validateGadgetID(string gadgetID)
    {
        string pattern = @"^[A-Z]\d{3}$";

        if(Regex.IsMatch(gadgetID, pattern))
        {
            return true;
        }
        else
        {
            throw new InvalidGadgetException("Invalid gadget ID");
        }
    }

    public bool validateWarrantyPeriod(int period)
    {
        if(period>=6 && period <= 36)
        {
            return true;
        }
        else
        {
            throw new InvalidGadgetException("Invalid warranty period");
        }
    }
}