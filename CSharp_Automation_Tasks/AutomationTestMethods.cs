using AllPrograms;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Automation_Tasks
{
   
    [TestClass]
    public sealed class AutomationTestMethods
    {
        ConaditionalLoops loops;
        OOPs oops;
        Employee employees;
        ArrayString arrayStrg;
        FileHandling fileHandling;
        AccessModifiers accessModifiers;
        Access_Modofiers access_modofiers;
        DerivedClass derivedClass;
        Calculator calculator;
        Icalc icac;
        TaskSchedulerNew taskScheduler;
        Collections collections;


        [TestInitialize]
        public void initialize()
        {
             loops = new ConaditionalLoops();   
            oops = new OOPs();
            employees = new Employee();
            arrayStrg = new ArrayString();
            fileHandling = new FileHandling();
            accessModifiers = new AccessModifiers();
            access_modofiers = new Access_Modofiers();
            derivedClass = new DerivedClass();
            icac = new Calculator();
            calculator = new Calculator();
            taskScheduler = new TaskSchedulerNew();
            collections = new Collections();
           

        }

        /* Task Description : 
          User should be able to input the name of any 4 team members, Store the Names in a List
          Iterate through the List and print the longest name
         */
        [TestMethod]
        public void Task1_ConditionLoops()
        {           
           
            List<string> names = new List<string>();           
            loops.EnterTeamatesName();
            names = loops.team_members;
            string largeName = loops.GetLargestName(names);
            loops.Display(largeName);

        }

        /* Task Description :Use the conditional statement to print the factorial of a number.
           Use the conditional statement to print the Fibonacci series
        */

        [TestMethod]
        public void Task1_ConditionLoops_factorial_fibnacci()
        {

            /* Calculate the factorial of the given number*/
            int factorial = loops.FactorialOfGivenNumber(Task_Constants.fact);
            loops.Display(factorial.ToString());
            loops.DisplayFibonacciSeries(Task_Constants.fib);

            
        }

        /*Task Description : Create a class named 'Employee' in your console application project
            From the main method of program.cs,create and Initialize the Employee object
            Create a method named PrintedSalary in your Employee class.
            The PrintSalary method should print the Salary Details of Employee.
            Through the Main method of Program.cs:
            Print the Name of Employee in UpperCase
            Print Salary
            */
        [TestMethod]
        public void Task2_OOPS_employeeDetails()
        {
            /* Display Employee data */
            employees.PrintSalary(employees.ReadCsvData());

        }

        /*Task Description : Design Calculator Class with 4 operations , which takes 2 Parameters and returns appropriate results :
         * Addition, Subtraction, Multiplication, and Division*/
        [TestMethod]
        public void Task2_OOPS_Calculatpor_Class()
        {

            calculator.Display(calculator.Add(20, 23).ToString(), "Addition");
            calculator.Display(calculator.Sub(24, 23).ToString(), "Subtraction");
            calculator.Display(calculator.Mult(20, 2).ToString(), "Multiplication");
            calculator.Display(calculator.Div(20, 4).ToString(), "Division");
        }

        /*Task Description : Create Calculator Instance and perform 4 Operations for numbers 10 and 20.5 and print results in console*/
        [TestMethod]
        public void Task2_OOPS_Calculatpor_Interface()
        {
            icac.Display(icac.Add(10, 20.51).ToString(), "IAddition");
            icac.Display(icac.Sub(10, 20.5).ToString(), "ISubtraction");
            icac.Display(icac.Mult(10, 20.5).ToString(), "IMultiplication");
            icac.Display(icac.Div(20.5, 10).ToString(), "IDivision");


        }
        /*Given Number is Odd or Even*/
        [TestMethod]
        public void Task2_OOPS_EvenOrOdd()
        {

            oops.displayEvenOdd(Task_Constants.N);

        }

        /*Calculate Factorial of given number ‘n’ */
        [TestMethod]
        public void Task2_OOPS_FactorialOfGivenNumberN()
        {
            oops.displayFactorial(Task_Constants.fact);

        }

        /*Print your name in upper case
        Get the first character from your last name
        User should be able to input first name and last name
        Concatenate the first name and last name
        Display the output
        Display the output
         */

        [TestMethod]
        public void Task3_Strings()
        {
            
            string fullName = arrayStrg.Concat_FirstName_LastName(Task_Constants.firstName, Task_Constants.LastName);
            arrayStrg.Display(fullName, $"Concatname firstName: {Task_Constants.firstName} and LastName: {Task_Constants.LastName}");

            string firstLetter = arrayStrg.get_firstLetter_from_Lastname(Task_Constants.Myname);
            arrayStrg.Display(firstLetter, $"Get the first letter from LastName of  {Task_Constants.Myname} is ");

            arrayStrg.DisplyUserNameInUpperCase(Task_Constants.Myname);

        }

        /*Remove duplicates from an ArrayList list = new ArrayList() { 1, 2, 2, 3, 4, 4, 5 };
          Counting Frequencies of Elements in string text = "hello world hello";
          Problem involves checking if a string containing various types of parentheses (e.g., (), {}, []) is balanced            
          Find the first repeating number while traversing from left to right in {1,2,3,4,3,5,6,2,7,8,1,0,9,1}
        */

        [TestMethod]
        public void Task4_Collections()
        {
            var uniqueList = collections.RemoveDuplicates(Task_Constants.list);

            collections.DispalyResults(uniqueList, "After removed the duplicates from ArrayList { 1, 2, 2, 3, 4, 4, 5 }");

            var charCount = collections.CharCountFromText(Task_Constants.text);
            collections.DispalyResults(charCount, $"Counting Frequencies of Elements in string text = {Task_Constants.text} is : ");

            var IsBalancedParenthesis = collections.IsBalancedParenthesis(Task_Constants.balanceString);
            collections.DispalyResults(IsBalancedParenthesis, Task_Constants.balanceString);

            var firstRepeatingNum = collections.FindFirstRepeatingNumber(Task_Constants.number);
            collections.DispalyResults(firstRepeatingNum, "Find the first repeating number while traversing from left to right in {1,2,3,4,3,5,6,2,7,8,1,0,9,1} is: ");

        }


        /*Create a task scheduling system where tasks are processed in the order they arrive.
         */

        [TestMethod]
        public void Task4_Collections_Queues()
        {
            taskScheduler.AllTasksExecution();
        }

        /*Create a class Shield with two private fields: string _identifier and int _power. Add a parameterless public constructor to the class Shield that assigns 10 to _power and "Default" to _identifier.
         * 1. output : "Access denied". You are allowed to change no more than two access modifiers.
            2. output : "Access granted". You are allowed to change no more than two access modifiers, and in addition, you cannot change anything inside the Main method.
         */
        [TestMethod]
        public void Task5_access_modifiers()
        {
            accessModifiers.Display();
            access_modofiers.Calling_Private_Method();
            derivedClass.MyProtectedMethod();

        }

        /*
         * You are assigned to develop a project in which project manager wants following functionality.
        Create Student Folder in D drive using DirectoryInfo class.
        Ask student's name and create a file with that name and store in Student folder.
        Ask student's details and save information in that file.
        Print following option on console screen.
        View Saved File
        View Directory Details
         */

        [TestMethod]
        public void Task6_FileHandling()
        {
            fileHandling.CreateStundentDirectory();

        }     

    }
}
