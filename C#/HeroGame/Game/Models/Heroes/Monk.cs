using Game.Models.Common;
using Game.Utility;

namespace Game.Heroes
{
    class Monk : Hero
    {
        public Monk(int healthPoints, int attackPoints, int armorPoints)
            : base(healthPoints, attackPoints, armorPoints)
        {
        }

        public override void Defend(int attackPoints)
        {
            if (!ChanceDeterminator.Determine(30))
            {
                if (this.ArmorPoints <= 0)
                {
                    this.HealthPoints -= attackPoints;
                }
                else
                {
                    if (attackPoints > this.ArmorPoints)
                    {
                        this.HealthPoints += attackPoints - this.ArmorPoints;
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
