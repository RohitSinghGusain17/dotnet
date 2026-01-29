using NUnit.Framework;
using MyLibrary;

namespace MyLibrary.Tests;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calc;

    [SetUp] // This runs before every test method
    public void Setup()
    {
        _calc = new Calculator();
    }

    [Test]
    public void All_Assertion_Examples()
    {
        // 1. Equality Assertions
        Assert.That(_calc.Add(2, 2), Is.EqualTo(4));
        Assert.That(_calc.Add(2, 2), Is.Not.EqualTo(5));

        // 2. String Assertions
        string msg = _calc.GetGreeting("Alice");
        Assert.That(msg, Does.Contain("Alice"));
        Assert.That(msg, Does.StartWith("Hello"));
        Assert.That(msg, Is.Not.Empty);

        // 3. Numeric Ranges & Precision
        Assert.That(_calc.Divide(10, 3), Is.EqualTo(3.33).Within(0.01));
        Assert.That(10, Is.GreaterThan(5));
        Assert.That(10, Is.InRange(1, 100));

        // 4. Boolean & Nulls
        Assert.That(true, Is.True);
        Assert.That((object)null, Is.Null);

        // 5. Collection Assertions
        var list = new List<int> { 1, 2, 3 };
        Assert.That(list, Has.Exactly(3).Items);
        Assert.That(list, Contains.Item(2));
        Assert.That(list, Is.Unique);

        // 6. Exception Assertions
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
        Assert.Throws<ArgumentNullException>(() => _calc.GetGreeting(null));
        Assert.Throws<ArgumentException>(() => _calc.Divide(10, -5));
    }

    // 7. Parameterized Tests (Running the same test with different data)
    [TestCase(1, 2, 3)]
    [TestCase(-1, 1, 0)]
    [TestCase(100, 200, 300)]
    public void Add_MultipleInputs_ReturnsExpected(int a, int b, int expected)
    {
        Assert.That(_calc.Add(a, b), Is.EqualTo(expected));
    }
}