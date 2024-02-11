using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР7.RPGSaga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите количество игроков (от 2 до 4): ");
                    int numPlayers = int.Parse(Console.ReadLine());
                    if (numPlayers >= 2 && numPlayers <= 4)
                    {
                        RPGSaga game = new RPGSaga(numPlayers);
                        game.StartGame();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Пожалуйста, введите число от 2 до 4.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Пожалуйста, введите целое число.");
                }
            }
        }
    }
}
