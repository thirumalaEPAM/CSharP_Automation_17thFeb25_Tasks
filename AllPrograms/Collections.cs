using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPrograms
{
    public class Collections
    {
        /// <summary>
        /// This Method is used to remove duplicates from ArrayList
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ArrayList RemoveDuplicates(ArrayList list)
        {
            //ArrayList list = new ArrayList() { 1, 2, 2, 3, 4, 4, 5 };
            ArrayList lst_NoDuplicates = new ArrayList();
            foreach (var item in list)
            {
                if (!lst_NoDuplicates.Contains(item))
                    lst_NoDuplicates.Add(item);


            }
            return lst_NoDuplicates;
        }
        /// <summary>
        /// Counting Frequencies of Elements in given string text = "hello world hello"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Dictionary<char, int> CharCountFromText(string text)
        {
            char[] list = text.ToCharArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (var item in list)
            {
                if (!dict.ContainsKey(item))
                    dict.Add(item, 1);
                else dict[item] += 1;

            }
            return dict;
        }

        /// <summary>
        /// Problem involves checking if a string containing various types of parentheses (e.g., (), {}, []) is balanced
        /// </summary>
        /// <param name="list"></param>
        public bool IsBalanced(string input)
        {
            // Define a stack to keep track of opening brackets
            Stack<char> stack = new Stack<char>();

            // Define a mapping of closing brackets to their corresponding opening brackets
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

            // Iterate through each character in the input string
            foreach (char c in input)
            {
                // If it's an opening bracket, push it onto the stack
                if (bracketPairs.ContainsValue(c))
                {
                    stack.Push(c);
                }
                // If it's a closing bracket, check if it matches the top of the stack
                else if (bracketPairs.ContainsKey(c))
                {
                    // If the stack is empty or the top doesn't match, it's unbalanced
                    if (stack.Count == 0 || stack.Pop() != bracketPairs[c])
                    {
                        return false;
                    }
                }
            }

            // If the stack is empty, all brackets are balanced
            return stack.Count == 0;
        }


        /// <summary>
        /// Find the first repeating number while traversing from left to right in {1,2,3,4,3,5,6,2,7,8,1,0,9,1}
        /// </summary>
        public int FindFirstRepeatingNumber(int[] number)
        {
            HashSet<int> list = new HashSet<int>();

            foreach (int item in number)
            {
                if (list.Contains(item)) return item;
                else list.Add(item);
            }

            return -1;

        }

        public void DispalyResults(bool result, string text)
        {
            string IsBalanced = Convert.ToBoolean(result) ? $"Given String {text} is Balanced Parenthesis" : $"Given string {text} is Not Balanced parenthesis";

            Console.WriteLine(IsBalanced);
        }

        public void DispalyResults(ArrayList result, string text)
        {
            Console.WriteLine($"{text} : ");
            foreach (int item in result)
            {
                Console.WriteLine(item);

            }
        }

        public void DispalyResults(Dictionary<char,int> result, string text)
        {
            Console.WriteLine($"{text}");
            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }
        }

        public void DispalyResults(int result, string text)
        {

            Console.WriteLine($"{text} : {result}");

        }    
            
        
    }
    public class TaskSchedulerNew
    {
        private Queue<Action> taskQueue = new Queue<Action>();
        private object lockObject = new object();
        private bool isRunning = true;

        public TaskSchedulerNew()
        {
            // Start the task processing loop in a separate thread
            Task.Run(() => ProcessTasks());
        }

        // Add a task to the queue
        public void ScheduleTask(Action task)
        {
            lock (lockObject)
            {
                taskQueue.Enqueue(task);
                Monitor.Pulse(lockObject); // Notify the processing thread that a new task is available
            }
        }

        // Process tasks in the queue
        /// <summary>
        /// Create a task scheduling system where tasks are processed in the order they arrive
        /// </summary>
        private void ProcessTasks()
        {
            while (isRunning)
            {
                Action task = null;

                lock (lockObject)
                {
                    while (taskQueue.Count == 0 && isRunning)
                    {
                        Monitor.Wait(lockObject); // Wait for a task to be added
                    }

                    if (taskQueue.Count > 0)
                    {
                        task = taskQueue.Dequeue();
                    }
                }

                if (task != null)
                {
                    try
                    {
                        task.Invoke(); // Execute the task
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Task execution failed: {ex.Message}");
                    }
                }
            }
        }

        // Stop the task scheduler
        public void Stop()
        {
            isRunning = false;
            lock (lockObject)
            {
                Monitor.Pulse(lockObject); // Wake up the processing thread to exit
            }
        }
    }
}
