public class RobotSafetyException : Exception
{
    public RobotSafetyException(string message) : base(message)
    {

    }
}

public class RobotHazardAuditor
{
    public double machineRiskFactor(string machineryState)
    {
        double factor = 0;
        switch (machineryState)
        {
            case "Worn":
                factor = 1.3;
                break;
            case "Faulty":
                factor = 2.0;
                break;
            case "Critical":
                factor = 3.0;
                break;
        }
        return factor;
    }
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        double risk = 0;
        if (armPrecision < 0.00 || armPrecision > 1.00)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }
        else if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }
        else if (!(machineryState == "Worn" || machineryState == "Faulty" || machineryState == "Critical"))
        {
            throw new RobotSafetyException("Error: Unsopported machinery state");
        }
        else
        {
            risk = ((1.00 - armPrecision) * 15.00) + (workerDensity * machineRiskFactor(machineryState));
        }

        return risk;
    }
}