using System;

namespace person{
    public class Person
    {
        #region Declaration
        public int id {get; set;}
        public int age {get; set;}
        public string? name {get; set;}
        #endregion

        /// <summary>
        /// This is the private constructor of person class
        /// </summary>
        private Person()
        {
            id=0;
            age=0;
            name="abc";
        }

        /// <summary>
        /// This is the public constructor of person class with 2 parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="age"></param>
        public Person(int id, int age)
        {
            this.id=id;
            this.age=age;
        }

        /// <summary>
        /// This is the public constructor of person class with 3 parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="age"></param>
        /// <param name="name"></param>
        public Person(int id, int age, string name)
        {
            this.id=id;
            this.age=age;
            if (name.ToLower().Contains("idiot"))
            {
                throw new ArgumentException("Don't write idiot");
            }
            this.name=name;
        }
    }

    /// <summary>
    /// Class Man
    /// </summary>
    public class Man : Person
    {
        public string? playing {get; set;}

        public Man(int id, int age, string name, string playing) : base(id, age, name)
        {
            this.playing=playing;
        }
    }

    /// <summary>
    /// Class Woman
    /// </summary>
    public class Woman : Person
    {
        public string? playormanage {get; set;}
        public Woman(int id, int age, string name, string playormanage) : base(id, age, name)
        {
            this.playormanage=playormanage;
        }
    }
}