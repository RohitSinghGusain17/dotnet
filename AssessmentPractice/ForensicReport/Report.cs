public class ForensicReport
{
    private Dictionary<string, DateOnly> reportDict = new Dictionary<string, DateOnly>();
    
    public void addReportDetails(string reportingOfficerName, DateOnly reportDate)
    {
        reportDict[reportingOfficerName]=reportDate;
    }

    public List<string> getOfficersWhoFiledReportsOnDate(DateOnly reportFiledDate)
    {
        var result = reportDict.Where(x=>x.Value==reportFiledDate).Select(x=>x.Key).ToList();
        return result;
    }
}
