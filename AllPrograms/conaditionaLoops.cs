using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AllPrograms
{
    public class conaditionaLoops
    {
        public List<string> team_members= new List<string>();
       
        public void enterTeamatesName()
        {
            for (int i = 0; i < Task_Constants.totalTeam; i++)
            {
                team_members.Add(Task_Constants.names[i]);
                Console.WriteLine(Task_Constants.names[i]);

            }

        }

        public string get_largestName(List<string> names)
        {
            string bigName = null;
            for (int i = 0;i < names.Count;i++)
            {
                if (i+1 == names.Count)
                {
                                      
                      bigName = bigName.Length < names[i].Length ? names[i].ToString() : bigName;
                }   

                else if (names[i].Length < names[i + 1].Length)
                    bigName = names[i+1].ToString();
                else
                    bigName = names[i].ToString();



            }

            return bigName; 

        }

        public int factorial(int n)
        {
            int fact = 0;
            if (n == 0) return 1;
            else if (n == 1) return 1;
            else
            {
               return n*factorial(n-1);
            }          
        
        }

        public int fibonacii(int n)
        {
            if (n <=1) return n;
            return fibonacii(n-1) + fibonacii(n-2);

        }
        public void display_fibonacci(int n)
        {
            Console.WriteLine($"Fibonacci Series for the given number {Task_Constants.fib} ");
            List<string> list_fib = new List<string>();
            for (int i = 0; i < n; i++)
            {                
                Console.Write($" {fibonacii(i)}  ");
            }
        
        }


        public void display(string name)
        { 
            Console.WriteLine($"result: {name}");
        }

    }


}
