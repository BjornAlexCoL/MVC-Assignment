using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Assignment.Models
{
    public class FeverCheck
    {
        static public string GetFeverResponse(float temp,string tempScale)
        {
            string feverResponse="You look healty. Time to work!";
            if (temp >= ((tempScale== "Farenheit")? 98.6 : 37))
            {
                feverResponse = "I, as a computer, would say you got some fever";
            }
            if (temp < ((tempScale == "Farenheit") ? 95 : 35))
            {
                feverResponse = "I, as a computer, would say you are more or less dead";
            }
            return feverResponse;
        }
    }
}
