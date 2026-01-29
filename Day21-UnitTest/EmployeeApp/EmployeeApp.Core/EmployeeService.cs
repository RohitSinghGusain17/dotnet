using System.Collections.Generic;

public class EmployeeService
{
    private readonly IEmployeeRepository _repo;

    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public List<Employee> GetAllEmployees()
    {
        return _repo.GetAllEmployees();
    }
    public int GetEmployeeCount()
    {
        return _repo.GetAllEmployees().Count;
    }
}