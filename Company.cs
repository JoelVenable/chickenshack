using System;
using System.Collections.Generic;

namespace chickenshack
{
  public class Company
  {
    private List<Employee> _employees = new List<Employee>();
    public string Name { get; set; }

    public int AddEmployee(Employee employee)
    {
      int count = _employees.Count;
      _employees.Add(employee);
      return count;  // Becomes the new employee's id.
    }

    public Employee GetEmployeeById(int id) => _employees[id];
    

  }
}