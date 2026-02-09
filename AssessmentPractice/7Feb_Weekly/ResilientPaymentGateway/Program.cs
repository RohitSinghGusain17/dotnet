using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PaymentRequest
{
    
}
public class PaymentResult { public bool Success; }

public class PaymentService
{
    static List<DateTime> failures = new List<DateTime>();
    static DateTime circuitOpenTill = DateTime.MinValue;

    public async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest req)
    {
        if (DateTime.UtcNow < circuitOpenTill)
        {
            return new PaymentResult { Success = false };
        }

        for (int i = 0; i < 3; i++)
        {
            try
            {
                await Task.Delay(10);
                return new PaymentResult { Success = true };
            }
            catch
            {
                RecordFailure();
                if (DateTime.UtcNow < circuitOpenTill) break;
            }
        }
        return new PaymentResult { Success = false };
    }

    void RecordFailure()
    {
        var now = DateTime.UtcNow;
        failures.Add(now);
        failures.RemoveAll(x => (now - x).TotalMinutes > 1);
        if (failures.Count >= 5)
        {
            circuitOpenTill = now.AddSeconds(30);
        }
    }
}


[TestFixture]
public class PaymentServiceTests
{
    [Test]
    public async Task Payment_Success()
    {
        var svc = new PaymentService();
        var res = await svc.ProcessPaymentAsync(new PaymentRequest());
        Assert.IsTrue(res.Success);
    }

    [Test]
    public async Task CircuitBreaker_FailsFast()
    {
        var svc = new PaymentService();
        for (int i = 0; i < 5; i++)
            await svc.ProcessPaymentAsync(new PaymentRequest());

        var res = await svc.ProcessPaymentAsync(new PaymentRequest());
        Assert.IsFalse(res.Success);
    }
}