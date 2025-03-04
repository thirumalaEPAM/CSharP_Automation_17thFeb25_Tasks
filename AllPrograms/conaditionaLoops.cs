using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AllPrograms
{
    public class ConaditionalLoops
    {
        public List<string> team_members= new List<string>();
       
        public void EnterTeamatesName()
        {
            for (int i = 0; i < Task_Constants.totalTeam; i++)
            {
                team_members.Add(Task_Constants.names[i]);
                Console.WriteLine(Task_Constants.names[i]);

            }

        }

        public string GetLargestName(List<string> names)
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

        public int FactorialOfGivenNumber(int n)
        {
            int fact = 0;
            if (n == 0) return 1;
            else if (n == 1) return 1;
            else
            {
               return n*FactorialOfGivenNumber(n-1);
            }          
        
        }

        public int FibonacciOfGivenNumber(int n)
        {
            if (n <=1) return n;
            return FibonacciOfGivenNumber(n-1) + FibonacciOfGivenNumber(n-2);

        }
        public void DisplayFibonacciSeries(int n)
        {
            Console.WriteLine($"Fibonacci Series for the given number {n} ");
            List<string> list_fib = new List<string>();
            for (int i = 0; i < n; i++)
            {                
                Console.Write($" {FibonacciOfGivenNumber(i)}  ");
            }
        
        }


        public void Display(string name)
        { 
            Console.WriteLine($"result: {name}");
        }

    }


}
