# A Larger Example: The Chicken Shack

Consider the following program.

```csharp
using System;
using System.Collections.Generic;

namespace TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Company chickenShack = new Company() { Name = "Greasy Pete's Chicken Shack" };
            chickenShack.AddEmployee(new Employee() { FirstName = "Pete",  LastName = "Shackleton" });
            chickenShack.AddEmployee(new Employee() { FirstName = "Molly", LastName = "Frycook" });
            chickenShack.AddEmployee(new Employee() { FirstName = "Pat",   LastName = "Buttersmith" });

            List<int> employeeIds = new List<int>() { 0, 11, 2 };
            foreach(int id in employeeIds)
            {
                Employee employee = chickenShack.GetEmployeeById(id);
                Console.WriteLine($"Employee #{id} is {employee.FirstName} {employee.LastName}.");
            }
        }
    }

    public class Company
    {
        private List<Employee> _employees = new List<Employee>();
        public string Name { get; set; }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            return _employees[id];
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
```

When we run this program, we see the following in the Console.

```
Employee #0 is Pete Shackleton.

Unhandled Exception: System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index
   at System.Collections.Generic.List`1.get_Item(Int32 index)
   at TryCatch.Company.GetEmployeeById(Int32 id) in /home/tgwtg/programming/nss/trycatch/Program.cs:line 89
   at TryCatch.Program.Main(String[] args) in /home/tgwtg/programming/nss/trycatch/Program.cs:line 40
```

We see the output for Employee #0, but then the program ends due to an exception.

What caused the exception? Look closely at this line:

```csharp
List<int> employeeIds = new List<int>() { 0, 11, 2 };
```

The `employeeIds` is a list of employee IDs. The ID of an employee is the _index_ of that employee in the company's `_employees` list. However, notice the second element in `employeeIds` is `11`, but the only valid indexes in the company's `_employees` list are `0, 1, and 2`. This means when we look for an employee with ID `11`, we are looking for an employee that doesn't exist...therefor, we get an exception.

<br>

Let's change the code to handle the exception.

```csharp
try
{
    List<int> employeeIds = new List<int>() { 0, 11, 2 };
    foreach(int id in employeeIds)
    {
        Employee employee = chickenShack.GetEmployeeById(id);
        Console.WriteLine($"Employee #{id} is {employee.FirstName} {employee.LastName}.");
    }
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine("Something went wrong while finding employees");
}
```

Now we see

```
Employee #0 is Pete Shackleton.
Something went wrong while finding employees
```

We wrapped our code in a `try/catch` block and now our program has been improved. Our users will no longer see a scary error message.

But we can do better.

```csharp
List<int> employeeIds = new List<int>() { 0, 11, 2 };
foreach(int id in employeeIds)
{
    try
    {
        Employee employee = chickenShack.GetEmployeeById(id);
        Console.WriteLine($"Employee #{id} is {employee.FirstName} {employee.LastName}.");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Employee #{id} was not found in the company.");
    }
}
```

Now when we run the program we see

```
Employee #0 is Pete Shackleton.
Employee #11 was not found in the company.
Employee #2 is Pat Buttersmith.
```

By placing our `try/catch` block inside the loop, we are able to continue looping even after one of our employee lookups fails. Plus, we're able to print a better error message because we now have the ID that caused the exception.
