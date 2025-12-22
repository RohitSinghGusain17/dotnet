using System;

namespace visit
{
    public class Visitor
    {
        public int? id{get; set;}
        public string? name{get; set;}
        public string? LogHistory{get; set;}

        public Visitor()
        {
            LogHistory+= $"default created on {DateTime.Now.ToString()} {Environment.NewLine}";
        }
        public Visitor(int id) :this()
        {
            this.id=id;
            LogHistory+= $"ID created on {DateTime.Now.ToString()} {Environment.NewLine}";
        }

        public Visitor(int id, string name) : this(id)
        {
            this.name=name;
            LogHistory+=$"name created on {DateTime.Now.ToString()} {Environment.NewLine}";
        }
    }
}