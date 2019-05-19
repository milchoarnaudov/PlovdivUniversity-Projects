using Game.Models.Common;
using Game.Utility;

namespace Game.Heroes
{
    class Knight : Hero
    {
        public Knight(int healthPoints, int attackPoints, int armorPoints)
            : base(healthPoints, attackPoints, armorPoints)
        {
        }

        public override void Attack(Hero opponent)
        {
            if (ChanceDeterminator.Determine(10))
            {
                opponent.Defend(this.AttackPoints * 2);
            }
            else
            {
                 opponent.Defend(this.AttackPoints);
            }
        }

        public override void Defend(int attackPoints)
        {
            if (!ChanceDeterminator.Determine(20))
            {
                if (this.ArmorPoints <= 0)
                {
                    this.HealthPoints -= attackPoints;
                }
                else
                {
                    if (attackPoints > this.ArmorPoints)
                    {
                        this.HealthPoints += this.ArmorPoints - attackPoints;
                        this.ArmorPoints = 0;
                    }
                    else
                    {
                        this.ArmorPoints -= attackPoints;
                    }
                }
            }
        }
    }
}
