using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ПР7.RPGSaga
{
    internal class Knight : Player
    {
        public Knight(string name) : base(name) { }

        protected override void SpecialAbility(Player opponent)
        {
            int damage = (int)(Strength * 1.3);
            opponent.Health -= damage;
            logger.Log($"({GetType().Name}) {Name} использует (Удар возмездия) и наносит урон {damage} противнику ({opponent.GetType().Name}) {opponent.Name}");
        }
    }
}
