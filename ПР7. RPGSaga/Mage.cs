using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР7.RPGSaga
{
    internal class Mage : Player
    {
        public Mage(string name) : base(name) { }

        protected override void SpecialAbility(Player opponent)
        {
            logger.Log($"({GetType().Name}) {Name} использует (Заворожение) на противнике ({opponent.GetType().Name}) {opponent.Name}");
            opponent.SkipTurn = true;
        }
    }
}
