using System;
using Emp;

namespace Comp{
    public class Competition
    {
        #region
        public string compname = "";
        public List<Employee> Employees;
        #endregion

        #region Constructor
        public Competition(string name)
        {
            this.compname=name;
            Employees=new List<Employee>();
        }
        #endregion

        #region Add employee to competition
        public void addEmployee(Employee employee)
        {
            Employees.Add(employee);
        }
        #endregion
    }
}