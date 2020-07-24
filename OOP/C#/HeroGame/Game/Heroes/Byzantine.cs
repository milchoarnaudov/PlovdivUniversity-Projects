using Game.Utility;

namespace Game.Heroes
{
    class Byzantine : Hero
    {
        public Byzantine(int healthPoints, int attackPoints, int armorPoints)
            : base(healthPoints, attackPoints, armorPoints)
        {
        }

        public override void Defend(int attackPoints)
        {
            if (Helpers.DetermineChance(40))
            {
                this.HealthPoints = 0;
            }

            if (this.ArmorPoints <= 0)
            {
                this.HealthPoints -= attackPoints;
            }
            else
            {
                if (attackPoints > this.ArmorPoints)
                {
                    this.HealthPoints = attackPoints - this.ArmorPoints;
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
