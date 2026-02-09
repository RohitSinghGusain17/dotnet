using NUnit.Framework;
public class RateLimiter
{
    public DateTime timer = DateTime.Now;
    public int RequestCount = 0;
    public bool AllowRequest(string clientId, DateTime now)
    {
        if (RequestCount == 0)
        {
            timer=DateTime.Now.AddSeconds(10);
        }
        if (now > timer)
        { 
            RequestCount=0;
            timer=now.AddSeconds(10);
        }
        RequestCount++;

        if(RequestCount>5 && timer>=now)
        {
            Console.WriteLine("Try Again after some time...");
            return false;
        }
        
        return true;
    }
}

[TestFixture]
public class Test_RateLimiter
{
    [Test]
    public void Test_AllowRequest()
    {
        RateLimiter rateLimiter = new RateLimiter();
        bool test1 = rateLimiter.AllowRequest("user1",DateTime.Now);
        bool test2 = rateLimiter.AllowRequest("user1",DateTime.Now);
        bool test3 = rateLimiter.AllowRequest("user1",DateTime.Now);
        bool test4 = rateLimiter.AllowRequest("user1",DateTime.Now);
        bool test5 = rateLimiter.AllowRequest("user1",DateTime.Now);
        bool test6 = rateLimiter.AllowRequest("user1",DateTime.Now);
        bool test7 = rateLimiter.AllowRequest("user4",DateTime.Now.AddSeconds(11));

        Assert.That(test1,Is.EqualTo(true));
        Assert.That(test2,Is.EqualTo(true));
        Assert.That(test3,Is.EqualTo(true));
        Assert.That(test4,Is.EqualTo(true));
        Assert.That(test5,Is.EqualTo(true));
        Assert.That(test6,Is.EqualTo(false));
        Assert.That(test7,Is.EqualTo(true));
    }
}