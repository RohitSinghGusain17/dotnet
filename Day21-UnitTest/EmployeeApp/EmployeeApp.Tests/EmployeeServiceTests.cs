using NUnit.Framework;
using Moq;
using System.Collections.Generic;

[TestFixture]
public class EmployeeServiceTests
{
    [Test]
    public void GetEmployeeCount_ReturnsCorrectCount()
    {
        var mockRepo = new Mock<IEmployeeRepository>();
        mockRepo.Setup(r => r.GetAllEmployees()).Returns(new List<Employee>
        {
            new Employee{Id=1,Name="Ravi"},
            new Employee{Id=2,Name="Anu"}
        });

        var service = new EmployeeService(mockRepo.Object);

        int count = service.GetEmployeeCount();

        // Act
        int actual = service.GetAllEmployees().Count;

        // Arrange expected
        int expected = 2;
        Assert.That(actual, Is.EqualTo(expected));
    }
}