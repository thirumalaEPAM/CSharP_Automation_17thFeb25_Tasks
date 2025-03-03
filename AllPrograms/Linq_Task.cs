using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPrograms
{
    public class Linq_Task
    {

        public int GetFirstValidValue()
        {
            int validValues = Task_Constants.values.First(x => x > 30);
            return validValues;
        }

        public int GetValidCount()
        {

            int validValues = Task_Constants.values.Count(x => x >= 45);
            return validValues;
        }

    }
}
