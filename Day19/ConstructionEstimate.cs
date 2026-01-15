public class EstimateDetails
{
    public float ConstructinArea{get; set;}
    public float SiteArea{get; set;}

    public EstimateDetails ValidateConstructionEstimate(float constructionArea, float siteArea)
    {
        EstimateDetails estimateDetails1 = new EstimateDetails();
        if (constructionArea < siteArea)
        {
            EstimateDetails estimateDetails = new EstimateDetails{ConstructinArea=constructionArea, SiteArea= siteArea};
            return estimateDetails;
        }
        else if (constructionArea > siteArea)
        {
            throw new ConstructionEstimateException("Sorry your construction Estimate is not approved");
        }
        return estimateDetails1;
    }
}

public class ConstructionEstimateException : Exception
{
    public ConstructionEstimateException(string message) : base(message)
    {
        
    }
}