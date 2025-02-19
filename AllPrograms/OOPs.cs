using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace AllPrograms
{
    public class OOPs
    {
        public OOPs() { }
       public bool isEvenOdd(int num)
       {
            return num % 2 == 0;
       }
        public void displayEvenOdd(int num)
        {

            string evenOdd = isEvenOdd(num) ? "Even" : "Odd";
            Console.WriteLine($"The Given number is {evenOdd}");
            
        }
        public void displayFactorial(int num)
        {
            conaditionaLoops loops = new conaditionaLoops();
            int fact = loops.factorial(num);
            Console.WriteLine($"Factorial of a given number is  {fact}");

        }


    }
    public class calculator
    { 
        public calculator() { }
        public int add(int x, int y)
        {
            return x + y;
        }
        public int sub(int x, int y)
        {
            return x - y;
        }
        public float mult(float x, float y)
        {
            return x * y;
        }

        public float div(float x, float y)
        {
            return x / y;
        }
    }
    public interface calc
    {
        int add(int x, int y);
        int sub(int x, int y);
        float mult(float x, float y);
        float div(float x, float y);
    }

    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; }

        public List<Employee> read_data()
        {
            string file_path = "C://Users//Thirumala_Rajolu//source//repos//CSharP_Automation_17thFeb25_Tasks//AllPrograms//data1.csv";
            List<Employee> employees = new List<Employee>();
            using (var reader = new StreamReader(file_path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                employees = csv.GetRecords<Employee>().ToList();

            } 
            
            return employees;

        }

        public void PrintSalary(List<Employee> employees)
        {
            Console.WriteLine(" Employee Name  | Salary ");
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.EmpName.ToUpper()}  | {employee.Salary}");
            }
        }


    }


}
