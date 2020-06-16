using Game.Models.Common;
using Game.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Heroes
{
    class Templar : Hero
    {
        public Templar(int healthPoints, int attackPoints, int armorPoints)
            : base(healthPoints, attackPoints, armorPoints)
        {
        }

        public override void Defend(int attackPoints)
        {
            if (!ChanceDeterminator.Determine(50))
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
