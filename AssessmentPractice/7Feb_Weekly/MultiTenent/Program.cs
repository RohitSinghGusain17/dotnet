using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Transaction
{
    public string TenantId;
    public string Type;
    public decimal Amount;
    public DateTime Timestamp;
}

public class TenantReport
{
    public string TenantId;
    public decimal TotalCredit;
    public decimal TotalDebit;
    public int PeakHour;
    public bool IsSuspicious;
}

public class ReportGenerator
{
    public List<TenantReport> Generate(List<Transaction> txns)
    {
        var result = new List<TenantReport>();

        foreach (var grp in txns.GroupBy(x => x.TenantId))
        {
            var debits = grp.Where(x => x.Type == "Debit").OrderBy(x => x.Timestamp).ToList();

            bool suspicious = false;
            for (int i = 0; i + 3 < debits.Count; i++)
                if ((debits[i + 3].Timestamp - debits[i].Timestamp).TotalMinutes <= 5)
                    suspicious = true;

            var peakHour = grp.GroupBy(x => x.Timestamp.Hour).OrderByDescending(g => g.Count()).First().Key;

            result.Add(new TenantReport
            {
                TenantId = grp.Key,
                TotalCredit = grp.Where(x => x.Type == "Credit").Sum(x => x.Amount),
                TotalDebit = grp.Where(x => x.Type == "Debit").Sum(x => x.Amount),
                PeakHour = peakHour,
                IsSuspicious = suspicious
            });
        }
        return result;
    }
}

[TestFixture]
public class ReportGeneratorTests
{
    [Test]
    public void Generates_Report_Correctly()
    {
        var data = new List<Transaction>
        {
            new Transaction{TenantId="T1",Type="Debit",Amount=10,Timestamp=DateTime.Today.AddMinutes(1)},
            new Transaction{TenantId="T1",Type="Debit",Amount=10,Timestamp=DateTime.Today.AddMinutes(2)},
            new Transaction{TenantId="T1",Type="Debit",Amount=10,Timestamp=DateTime.Today.AddMinutes(3)},
            new Transaction{TenantId="T1",Type="Credit",Amount=50,Timestamp=DateTime.Today.AddHours(1)},
        };

        var reports = new ReportGenerator().Generate(data);

        var r1 = reports.First(x => x.TenantId == "T1");
        Assert.AreEqual(50, r1.TotalCredit);
        Assert.AreEqual(40, r1.TotalDebit);
        Assert.IsTrue(r1.IsSuspicious);
    }
}