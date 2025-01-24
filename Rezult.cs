using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGame
{
    class Rezult
    {
        public void WhoWin(int diceFacesNumber1, int diceFacesNumber2)
        {
            if (diceFacesNumber2 > diceFacesNumber1)
            {
                Console.WriteLine($"You win: ({diceFacesNumber2} > {diceFacesNumber1})!");
            }
            else if (diceFacesNumber2 == diceFacesNumber1)
            {
                Console.WriteLine($"Draw: ({diceFacesNumber1} = {diceFacesNumber2})!\"");
            }
            else
            {
                Console.WriteLine($"I win: ({diceFacesNumber1} > {diceFacesNumber2})!\"");
            }

        }
    }
}
