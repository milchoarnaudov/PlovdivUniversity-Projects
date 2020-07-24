using Game.Utility;

namespace Game.Heroes
{
    class BulgarianWarrior : Hero
    {
        public BulgarianWarrior(int healthPoints, int attackPoints, int armorPoints) 
            : base(healthPoints, attackPoints, armorPoints)
        {

        }
        public override void Attack(Hero opponent)
        {
            if (Helpers.DetermineChance(99))
            {
                opponent.Defend(this.AttackPoints * 2);
            }
            else
            {
                opponent.Defend(this.AttackPoints);
            }
        }
    }
}
