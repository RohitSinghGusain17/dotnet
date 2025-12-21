using System;
using Emp;
using Comp;
namespace Win{
    public class Winner
    {
        #region Sort winner according to rank
        public void sort(List<Employee> employees)
        {
            // Sort employees by score (descending)
            employees.Sort((e1, e2) => e2.score.CompareTo(e1.score));

            // Assign ranks
            int rank = 1;
            foreach (Employee emp in employees)
            {
                emp.rank = rank;
                rank++;
            }
        }
        #endregion

        #region Display winners
        public void display(List<Employee> employees)
        {
            Console.WriteLine("Winner List");
            foreach (Employee emp in employees)
            {
                Console.WriteLine(
                    $"Rank: {emp.rank}, ID: {emp.empid}, Name: {emp.name}, Score: {emp.score}"
                );
            }
        }
        #endregion
    }
}