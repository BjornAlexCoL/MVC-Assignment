using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Assignment.Models
{
    public class NumberGuessingService
    {
        static int guesses;
        static int number;
        static public int GetNumber() {
            Random rnd = new Random();
            number=rnd.Next(1, 101);
            return number;
        }
        static public string EvaluateGuess(int guess)
        {
            string response;
            guesses++;
            if (guess == number)
            {
                response = $"Congratulation you guessed right in {guesses} guesses!";
                //RedirectToAction("Index");
            }
            else
            {
                response = $"You have guessed {guesses} so fare!"; 
                response += $" The number i am thingking of is {((guess < number) ? "higher" : "lesser")} then you guessed";
            }
            return response;
        }
    }
}
