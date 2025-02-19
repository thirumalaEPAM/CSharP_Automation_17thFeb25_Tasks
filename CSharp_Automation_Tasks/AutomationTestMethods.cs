using AllPrograms;
namespace CSharp_Automation_Tasks
{
   
    [TestClass]
    public sealed class AutomationTestMethods
    {
        conaditionaLoops loops;
        OOPs oops;
        Employee employees;
       

        [TestInitialize]
        public void initialize()
        {
             loops = new conaditionaLoops();   
            oops = new OOPs();
            employees = new Employee();


        }

        [TestMethod]
        public void Task1_ConditionLoops()
        {
            
           
            List<string> names = new List<string>();           
            loops.enterTeamatesName();
            names = loops.team_members;
            string largeName = loops.get_largestName(names);
            loops.display(largeName);

        }
        [TestMethod]
        public void Task1_ConditionLoops_factorial_fibnacci()
        {

            /* Calculate the factorial of the given number*/
            int factorial = loops.factorial(Task_Constants.fact);
            loops.display(factorial.ToString());
            loops.display_fibonacci(Task_Constants.fib);

            
        }

        [TestMethod]
        public void Task2_OOPS_employeeDetails()
        {
            /* Display Employee data */
            employees.PrintSalary(employees.read_data());

        }

    }
}
