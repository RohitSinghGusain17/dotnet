interface IBroadbandPlan
{
    int GetBroadbandPlanAmount();
}

class Black : IBroadbandPlan
{
    private readonly bool _isSubscriptionValid;
    private readonly int _discontPercentage;
    private const int PlanAmount=3000;

    public Black(bool isSubscriptionValid, int discontPercentage)
    {
        _isSubscriptionValid=isSubscriptionValid;
        if(discontPercentage<0 && discontPercentage > 50)
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            _discontPercentage=discontPercentage;
        }
    }

    public int GetBroadbandPlanAmount()
    {
        if (_isSubscriptionValid)
        {
            return PlanAmount- (int)(((double)_discontPercentage/100.00) * (double)PlanAmount);
        }
        else
        {
            return PlanAmount;
        }
    }
}

class Gold : IBroadbandPlan
{
    private readonly bool _isSubscriptionValid;
    private readonly int _discontPercentage;
    private const int PlanAmount=1500;

    public Gold(bool isSubscriptionValid, int discontPercentage)
    {
        _isSubscriptionValid=isSubscriptionValid;
        if(discontPercentage<0 && discontPercentage > 30)
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            _discontPercentage=discontPercentage;
        }
    }

    public int GetBroadbandPlanAmount()
    {
        if (_isSubscriptionValid)
        {
            return PlanAmount - (int)(((double)_discontPercentage/100.00) * (double)PlanAmount);
        }
        else
        {
            return PlanAmount;
        }
    }
}

class SubscribePlan
{
    private readonly IList<IBroadbandPlan> _broadbandPlans;

    public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
    {
        _broadbandPlans=broadbandPlans;
    }

    public IList<Tuple<string,int>> GetSubscriptionPlan()
    {
        if (_broadbandPlans == null)
        {
            throw new ArgumentNullException();
        }
        IList<Tuple<string,int>> tuples = new List<Tuple<string,int>>();
        foreach(var i in _broadbandPlans)
        {
            string plan = "";
            if(i is Black)
            {
                plan = "Black";
            }
            else
            {
                plan = "Gold";
            }

            int value = i.GetBroadbandPlanAmount();
            tuples.Add(new Tuple<string,int>(plan,value));
        }

        return tuples;
    }
}