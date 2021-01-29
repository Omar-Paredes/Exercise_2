using System;
namespace mvc_basics_assign_1_3.Models
{
    public class GuessingService
    {
        public static string CheckNumber(int userInput, int randomNumber)
        {
            if (userInput <= 0 || userInput > 100 || Convert.ToString(userInput) == string.Empty)
            {
                return "Please input a correct value (1-100)";
            }
            else if (userInput == randomNumber)
            {
                return "Congratulations you guessed the right number";
            }
            else
            {
                return "Unfortunately you guessed the wrong number.\tPlease try again";
            }
        }
    }
}
