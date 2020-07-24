using System;

namespace Game.Heroes
{
    public abstract class Hero
    {
        public Hero(int healthPoints, int attackPoints, int armorPoints)
        {
            HealthPoints = healthPoints;
            AttackPoints = attackPoints;
            ArmorPoints = armorPoints;
        }

        public int HealthPoints { get; protected set; }
        public int AttackPoints { get; protected set; }
        public int ArmorPoints { get; protected set; }

        public virtual void Attack(Hero opponent)
        {
            opponent.Defend(AttackPoints);
        }

        public virtual void Defend(int attackPoints)
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

        public override string ToString()
        {
            return $"Hero: {this.GetType().Name}" + Environment.NewLine + $"Health: {this.HealthPoints} Armor: {this.ArmorPoints}";
        }
    }
}
