using System.Text.RegularExpressions;
using NUnit.Framework;
public class ErrorSummary
{
    public string? ErrorCode { get; set; }
    public int Count { get; set; }
}
public class FileAnalyzer
{
    public IEnumerable<ErrorSummary> GetTopErrors(string filePath, int topN)
    {
        var errorCounts = new Dictionary<string, int>();
        Regex regex = new Regex(@"ERR\d{3}");
        foreach (var line in File.ReadLines(filePath))
        {
            var match = regex.Match(line);
            if (match.Success)
            {
                string errorCodes = match.Value;
                if (!errorCounts.ContainsKey(errorCodes))
                {
                    errorCounts[errorCodes] = 0;
                }
                errorCounts[errorCodes]++;
            }
        }
        return errorCounts.OrderByDescending(e => e.Value).Take(topN).Select(e => new ErrorSummary
        {
            ErrorCode = e.Key,
            Count = e.Value
        });
    }
}

[TestFixture]
public class Test_FileAnalyzer
{
    [Test]
    public void GetTopErrors()
    {
        FileAnalyzer fileAnalyzer = new FileAnalyzer();
        var actual = fileAnalyzer.GetTopErrors("error.txt", 3).ToList();

        var expected = new List<ErrorSummary>
        {
            new ErrorSummary { ErrorCode = "ERR123", Count = 5 },
            new ErrorSummary { ErrorCode = "ERR133", Count = 1 },
            new ErrorSummary { ErrorCode = "ERR143", Count = 1 }
        };
        Assert.That(actual.Select(x => (x.ErrorCode, x.Count)), Is.EqualTo(expected.Select(x => (x.ErrorCode, x.Count))));
    }
}