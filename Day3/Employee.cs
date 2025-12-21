using System;
using System.Data.Common;

namespace Emp{
    public class Employee
    {
        #region Declaration
        public string name = "";
        public int empid;
        public int score;
        public int rank;
        #endregion

        #region Constructor
        public Employee(string name, int empid, int score)
        {
            this.name=name;
            this.empid=empid;
            this.score=score;
        }
        #endregion
    }
}