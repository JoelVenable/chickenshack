using System;
using System.Collections.Generic;
namespace chickenshack
{
  class Program
  {
    static void Main(string[] args)
    {
      Company chickenShack = new Company()
      {
        Name = "Greasy Pete's Chicken Shack"
      };
      chickenShack.AddEmployee(new Employee()
      {
        FirstName = "Pete",
        LastName = "Shackleton"
      });
      chickenShack.AddEmployee(new Employee()
      {
        FirstName = "Molly",
        LastName = "Frycook"
      });
      chickenShack.AddEmployee(new Employee()
      {
        FirstName = "Pat",
        LastName = "Buttersmith"
      });

      List<int> employeeIds = new List<int>() { 0, 11, 2 };
      try
      {
        employeeIds.ForEach(id =>
        {
          Employee employee = chickenShack.GetEmployeeById(id);
          Console.WriteLine($"Employee #{id} is {employee.FirstName} {employee.LastName}");
        });
      }
      catch (ArgumentOutOfRangeException ex)
      {
        Console.WriteLine($"Something went wrong: {ex.Message}");
      }
    }
  }
}
