using System;

namespace studentdata
{
    public class Student
    {
        #region Declaration
        public string? name {get; set;}
        public int id {get; set;}
        public string? section {get; set;}
        #endregion

        #region Constructor
        public Student(string name, int id, string section)
        {
            this.name = name;
            this.id = id;
            this.section = section;
        }
        #endregion
    }
    public class HighSchool : Student
    {
        #region Declaration
        public string? Board { get; set; }
        #endregion

        #region Member function
        public HighSchool(string name, int id, string section, string board)
            : base(name, id, section)
        {
            Board = board;
        }
        #endregion
        
    }
    public class UG : HighSchool
    {
        #region Declaration
        public string? university{get; set;}
        #endregion
        #region Member function
        public UG(string name, int id, string section, string board,string University)
            : base(name, id, section,board)
        {
            university=University;
        }
        #endregion
    }
    public class PG : UG
    {
        #region Declaration
        public string? universityPG{get; set;}
        #endregion
        #region Member function
        public PG(string name, int id, string section, string board,string University,string UniversityPG)
            : base(name, id, section,board,University)
        {
            universityPG=UniversityPG;
        }
        #endregion
    }
}