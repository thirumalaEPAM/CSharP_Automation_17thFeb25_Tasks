using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Reflection.PortableExecutable;
using NLog;


namespace AllPrograms
{

    public class OOPs
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();        
        
        public bool IsEvenOdd(int num)
       {
            return num % 2 == 0;
       }
        public void DisplayEvenOdd(int num)
        {

            string evenOdd = IsEvenOdd(num) ? "Even" : "Odd";
            Console.WriteLine($"The {num} number is {evenOdd}");
            
        }
        public void DisplayFactorial(int num)
        {
            ConaditionalLoops loops = new ConaditionalLoops();
            int fact = loops.FactorialOfGivenNumber(num);
            Console.WriteLine($"Factorial of a given number is  {fact}");
            Logger.Info($"Factorial of a given number is  {fact}");

        }


    }
    public class Calculator :Icalc
    { 
        public Calculator() { }
        public int Add(int x, int y)
        {
            return x + y;
        }

        public double Add(int x, double y)
        {
            return x + y;
        }
        public int Sub(int x, int y)
        {
            return x - y;
        }
        public double Sub(int x, double y)
        {
            return x - y;
        }       

        public double Mult(int x, double y)
        {
            return x * y;
        }

        public int Mult(int x, int y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            try
            {
                if (y == 0) throw new DivideByZeroException("Divide By Zero");
                else return x / y;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("General Exception: " + e.Message);
                return -9.9999; // took the -9.9999 to handle the infinite value
            }

        }
        
        public void Display(string result, string message)
        {
            if (result != "-9.9999")
            { 
                Console.WriteLine($"{message} of given numbers : {result}");
             }
        }
    }
    public interface Icalc
    {
        double Add(int x, double y);
        double Sub(int x, double y);
        double Mult(int x, double y);
        double Div(double x, double y);
        void Display(string result, string message);
    }

    public class Employee
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; }

        public List<Employee> ReadCsvData()
        {
            string currentDirectory = Directory.GetCurrentDirectory();            
            string file_path = $"{currentDirectory.Split(new[] { Task_Constants.delimeter }, StringSplitOptions.None)[0]}//AllPrograms//data1.csv";
            //string file_path = "C://Users//Thirumala_Rajolu//source//repos//CSharP_Automation_17thFeb25_Tasks//AllPrograms//data1.csv";
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
               Logger.Info($"{employee.EmpName.ToUpper()}  | {employee.Salary}");
                
            }
          
        }


    }


}
