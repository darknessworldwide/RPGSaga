using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР7.RPGSaga
{
    internal class Archer : Player
    {
        private bool fireArrowsUsed;
        private int fireDamage;
        private bool fireEffect;

        public Archer(string name) : base(name)
        {
            fireArrowsUsed = false;
            fireDamage = 2;
            fireEffect = false;
        }

        protected override void SpecialAbility(Player opponent)
        {
            if (!fireArrowsUsed)
            {
                logger.Log($"({GetType().Name}) {Name} использует (Огненные стрелы) и противник ({opponent.GetType().Name}) {opponent.Name} загорается");
                fireArrowsUsed = true;
                fireEffect = true;
            }
            else
            {
                NormalAbility(opponent);
            }
        }

        private void ApplyFireDamage(Player opponent)
        {
            if (fireEffect)
            {
                logger.Log($"({opponent.GetType().Name}) {opponent.Name} горит и получает {fireDamage} урона от огня");
                opponent.Health -= fireDamage;
            }
        }

        public override void Attack(Player opponent)
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
            ApplyFireDamage(opponent);
        }
    }
}
