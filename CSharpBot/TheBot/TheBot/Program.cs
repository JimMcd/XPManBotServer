using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var opponent = Console.ReadLine().Trim();
            var chips = Convert.ToInt32(Console.ReadLine().Trim());
            var card = Console.ReadLine().Trim();

            while (card != "GAME OVER")
            {
                var action = Console.ReadLine();
                while (action != "HAND OVER")
                {
                    Console.WriteLine("BET");
                    var opponentAction = Console.ReadLine();
                }

                card = Console.ReadLine().Trim();
            }
        }
    }
}
