using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basics_assign_1_3.Models
{
    public class CheckFever
    {
        public static string TempCheck(double userTemp)
        {
            if (userTemp > 38.8)
            {
                return "You have a fever";
            }
            else
            {
                return "return to work";
            }

        }
    }
}
