using System;
using Emp;
using Comp;
using Win;
using person;
using studentdata;

public class Program
{
    #region Person.cs code
    // public string getDetails(Person person)
    // {
    //     string result = string.Empty;
    //     if(person is Man)
    //     {
    //         Man man = (Man) person;
    //         result = $"ID : {man.id} name : {man.name} age : {man.age} playing : {man.playing}";
    //     }
    //     if(person is Woman)
    //     {
    //         Woman woman = (Woman) person;
    //         result = $"ID : {woman.id} name : {woman.name} age : {woman.age} playing : {woman.playormanage}";
    //     }
    //     return result;
        // Console.WriteLine("name : "+ person.name + " age : "+person.age+ " id : "+person.id);
    // }

    // public void getManDetails(Man man)
    // {
    //     Console.WriteLine("name : "+ man.name + " age : "+man.age+ " id : "+man.id+" playing : "+man.playing);
    // }

    // public void getWomanDetails(Woman woman)
    // {
    //     Console.WriteLine("name : "+ woman.name + " age : "+woman.age+ " id : "+woman.id+" playing : "+woman.playormanage);
    // }
    #endregion

    public static void Main(string[] args)
    {
        #region Code of Employee, competition, winner
        Competition comp = new Competition("Project Competition");
        comp.addEmployee(new Employee("rohit",101,10));
        comp.addEmployee(new Employee("emp2",102,8));
        comp.addEmployee(new Employee("emp3",103,9));
        Winner winner = new Winner();
        winner.sort(comp.Employees);
        winner.display(comp.Employees);

        Console.ReadLine();
        #endregion


        #region Code of Person
        // Program program = new Program();
        // Person person = new Person(1,30,"rohit");
        // // program.getDetails(person);
        // Man m = new Man{id=1,age=10,name="rohit",playing="football"};
        // person = m;
        // string? result = program.getDetails(m);
        // Console.WriteLine(result);
        #endregion


    }
}