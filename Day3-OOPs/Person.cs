using System;
using System.Security.Cryptography.X509Certificates;

namespace person{
    public class Person
    {
        // private Person()
        // {
        //     id=0;
        //     age=0;
        //     name="abc";
        // }
        public int id {get; set;}
        public int age {get; set;}
        public string? name {get; set;}

        // public Person(int id, int age, string name)
        // {
        //     this.id=id;
        //     this.age=age;
        //     this.name=name;
        // }
    }

    public class Man : Person
    {
        public string? playing {get; set;}
    }

    public class Woman : Person
    {
        public string? playormanage {get; set;}
    }
}