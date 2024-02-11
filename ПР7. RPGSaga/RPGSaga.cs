using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ПР7.RPGSaga
{
    internal class RPGSaga
    {
        private List<string> playersNames = new List<string> { "Эльдар", "Артур", "Гэндальф", "Вильямс" };
        private List<Player> players = new List<Player>();
        private Logger logger = new Logger();
        private Random random = new Random();

        public RPGSaga(int numPlayers)
        {
            Type[] playerClasses = new Type[] { typeof(Knight), typeof(Mage), typeof(Archer) };

            for (int i = 0; i < numPlayers; i++)
            {
                int randomIndex = random.Next(playerClasses.Length);
                Type playerClass = playerClasses[randomIndex];
                string name = playersNames[random.Next(0, playersNames.Count)];
                playersNames.Remove(name);
                Player player = (Player)Activator.CreateInstance(playerClass, name);
                players.Add(player);
                logger.Log($"Игрок ({player.GetType().Name}) {player.Name} создан (Здоровье: {player.Health}, Сила: {player.Strength})");
            }
        }

        public void StartGame()
        {
            int roundNum = 1;
            while (players.Count > 1)
            {
                logger.Log($"\nКон {roundNum}.");
                Battle();
                roundNum++;
            }
            logger.Log($"Победитель: ({players[0].GetType().Name}) {players[0].Name}");
        }

        private void Battle()
        {
            players = players.OrderBy(x => Guid.NewGuid()).ToList();
            List<Player> playersToRemove = new List<Player>();
            for (int i = 0; i < players.Count; i += 2)
            {
                if (i + 1 < players.Count)
                {
                    Player player1 = players[i];
                    Player player2 = players[i + 1];
                    logger.Log($"({player1.GetType().Name}) {player1.Name} vs ({player2.GetType().Name}) {player2.Name}");
                    PerformCombat(player1, player2, playersToRemove);
                }
            }

            foreach (Player player in playersToRemove)
            {
                players.Remove(player);
            }
        }

        private void PerformCombat(Player player1, Player player2, List<Player> playersToRemove)
        {
            while (player1.Health > 0 && player2.Health > 0)
            {
                ExecuteTurn(player1, player2);
                if (player2.Health <= 0)
                {
                    logger.Log($"({player2.GetType().Name}) {player2.Name} погибает\n");
                    playersToRemove.Add(player2);
                    break;
                }

                ExecuteTurn(player2, player1);
                if (player1.Health <= 0)
                {
                    logger.Log($"({player1.GetType().Name}) {player1.Name} погибает\n");
                    playersToRemove.Add(player1);
                    break;
                }
            }
        }

        private void ExecuteTurn(Player attacker, Player defender)
        {
            if (!attacker.SkipTurn)
            {
                attacker.Attack(defender);
            }
            else
            {
                attacker.SkipTurn = false;
                logger.Log($"({attacker.GetType().Name}) {attacker.Name} заворожён и пропускает ход");
            }
        }
    }
}
