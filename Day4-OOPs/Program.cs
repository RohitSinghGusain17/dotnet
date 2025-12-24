using System;
using Emp;
using Comp;
using Win;
using person;
using studentdata;
using visit;
using constructorAdd;
using field;
using employee;
using account;
using family;

public class Program
{
    #region Person.cs code
    // public string getDetails(Person person)
    // {
    //     string result = string.Empty;
    //     if(person is Man)
    //     {
    //         Man man = (Man) person;
    //         result = $"ID : {man.id}\nname : {man.name}\nage : {man.age}\nplaying : {man.playing}";
    //     }
    //     if(person is Woman)
    //     {
    //         Woman woman = (Woman) person;
    //         result = $"ID : {woman.id}\nname : {woman.name}\nage : {woman.age}\nplaying : {woman.playormanage}";
    //     }
    //     return result;
    //     // Console.WriteLine("name : "+ person.name + " age : "+person.age+ " id : "+person.id);
    // }

    // public void getManDetails(Man man)
    // {
    //     Console.WriteLine("name : "+ man.name + "\n age : "+man.age+ "\n id : "+man.id+"\n playing : "+man.playing);
    // }

    // public void getWomanDetails(Woman woman)
    // {
    //     Console.WriteLine("name : "+ woman.name + "\n age : "+woman.age+ "\n id : "+woman.id+"\n playing : "+woman.playormanage);
    // }
    #endregion

    public static void Main(string[] args)
    {
        #region Code of Employee, competition, winner
        // Competition comp = new Competition("Project Competition");
        // comp.addEmployee(new Employee("rohit",101,10));
        // comp.addEmployee(new Employee("emp2",102,8));
        // comp.addEmployee(new Employee("emp3",103,9));
        // Winner winner = new Winner();
        // winner.sort(comp.Employees);
        // winner.display(comp.Employees);

        // Console.ReadLine();
        #endregion



        #region Code of Person
        //Program program = new Program();
        // Person persion = new Person(1,20);
        
        //Man m = new Man(1,10,"idiot","football");
        // person = m;
        // string? result = program.getDetails(m);
        // Console.WriteLine(result);

        // try
        // {
        //     Person person = new Person(1,30,"idiot");
        //     program.getDetails(person);
        // }
        // catch(Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        #endregion



        #region Code for consAdd
        //consAdd obj = new consAdd(3,4);
        #endregion



        #region visitor
        // Visitor obj = new Visitor(12,"rohit");
        // Console.WriteLine(obj.LogHistory);
        #endregion


        #region Callfield
        // CallField obj = new CallField();
        // obj.Id=100;
        // string result= obj.DisplayDetatils();
        // Console.WriteLine(result);
        #endregion


        #region EmployeeValidation
        // EmployeeValidation obj = new EmployeeValidation();
        // try
        // {
        //     Console.Write("Enter id:");
        //     int id = int.Parse(Console.ReadLine()!);
        //     Console.Write("Enter name:");
        //     string? name = Console.ReadLine()!;
        //     Console.Write("Enter rank:");
        //     string? rank =Console.ReadLine()!;
        //     obj.Id=id;
        //     obj.Rank=rank;
        //     obj.Name=name;
        //     string result = obj.DisplayResult();
        //     Console.WriteLine(result);
        // }
        // catch(Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        #endregion


        #region Account
        // Account acc = new Account{name="rohit",AccountId=1234};
        // Console.WriteLine(acc.GetAccountDetails());
        // SalesAccount salesAccount = new SalesAccount{name="abc",AccountId=34234, salesInfo=""};
        // Console.WriteLine(salesAccount.GetSalesAccountDetails());
        #endregion


        #region Family
        Son son = new Son();
        Console.WriteLine(son.InterestOn());
        #endregion
    }
}