using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР7.RPGSaga
{
    internal class Player
    {
        private string name;
        private int health;
        private int strength;
        private bool skipTurn;
        protected Logger logger = new Logger();
        private static Random random = new Random();

        public Player(string name)
        {
            this.name = name;
            this.health = random.Next(50, 101);
            this.strength = random.Next(10, 31);
            this.skipTurn = false;
        }

        public string Name { get { return name; } set { name = value; } }
        public int Health { get { return health; } set { health = value; } }
        public int Strength { get { return strength; } set { strength = value; } }
        public bool SkipTurn { get { return skipTurn; } set { skipTurn = value; } }

        public virtual string ChooseAbility()
        {
            return random.Next(0, 2) == 0 ? "normal" : "special";
        }

        public virtual void Attack(Player opponent)
        {
            string ability = ChooseAbility();
            if (ability == "special")
            {
                SpecialAbility(opponent);
            }
            else
            {
                NormalAbility(opponent);
            }
        }

        public void NormalAbility(Player opponent)
        {
            int damage = strength;
            opponent.health -= damage;
            logger.Log($"({GetType().Name}) {name} наносит урон {damage} противнику ({opponent.GetType().Name}) {opponent.name}");
        }

        protected virtual void SpecialAbility(Player opponent) { }
    }
}
