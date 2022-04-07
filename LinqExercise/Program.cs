using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /* Complete every task using Method OR Query syntax.
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             */

            //Print the Sum and Average of numbers      --done
            
            Console.WriteLine($"Sum of numbers: {numbers.Sum()}");
            Console.WriteLine($"Average of numbers: {numbers.Average()}");
            Console.WriteLine("----------");

            //Order numbers in ascending order and decsending order. Print each to console.     --done
            Console.WriteLine("Numbers in ascending order: ");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Numbers in decsending order: ");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("----------");

            //Print to the console only the numbers greater than 6      --done
            
            Console.WriteLine("Numbers only greater than 6: ");
            var greaterThanSix = numbers.Where(x => x > 6);
            foreach (var num in greaterThanSix)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("----------");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**  --done
            
            Console.WriteLine("Four numbers in acsending order: ");
            //numbers.OrderBy(x =>x).Take(4).ToList().ForEach(x => Console.WriteLine(x));
            var anyFour = numbers.OrderBy(x => x).Take(4).ToList();
            foreach (var num in anyFour)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------");

            //Change the value at index 4 to your age, then print the numbers in decsending order       --done
            
            Console.WriteLine("Put your age in index 4, then print numbers in descending order: ");
            numbers[4] = 21;
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("----------");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.       --done
            
            Console.WriteLine("Employees Full Names if it begins with C or S, ascending by First Name: ");
            var group = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S'))
                .OrderBy(x => x.FirstName);
            foreach (var employee in group)
            {
                Console.WriteLine($"{employee.FullName}");
            }

            Console.WriteLine("----------");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.     --done
            Console.WriteLine("Employees over 26 by age, then by first name: ");
            var group2 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var employee in group2)
            {
                Console.WriteLine($"{employee.FullName}, {employee.Age}");
            }

            Console.WriteLine("----------");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var group3 = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            Console.WriteLine("Sum of Years of Experience: ");
            Console.WriteLine(group3.Sum(x => x.YearsOfExperience));

            Console.WriteLine("Average of Years of Experience: ");
            Console.WriteLine(group3.Average(x => x.YearsOfExperience));

            Console.WriteLine("----------");

            //Add an employee to the end of the list without using employees.Add()      --done
            
            var group4 = employees.Append(new Employee("Spike", "Speigel", 27, 7)).ToList();
            Console.WriteLine("Add an employee to the end of the list: ");
            foreach (var employee in group4)
            {
                Console.WriteLine($"{employee.FullName}");
            }

            Console.WriteLine("----------");

        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
