using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AllPrograms
{
    public class ArrayString
    {
        /// <summary>
        /// Concatname given FirstName and LastName
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public string Concat_FirstName_LastName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }

        /// <summary>
        /// Get the first letter from user Last Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetFirstLetterFromLastname(string name)
        {
            string lastName = name.Split(' ')[1];
            char firstLetter = lastName.ToCharArray()[0];
            return firstLetter.ToString();
        }

        /// <summary>
        /// User name should display in Uppercase
        /// </summary>
        /// <param name="name"></param>

        public void DisplyUserNameInUpperCase(string name)
        {
            Console.WriteLine($"User Name in Uppercase : {name.ToUpper()}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void Display(string result, string displayText)
        {
            Console.WriteLine($"{displayText} : {result}");
        }
       

    }
}
