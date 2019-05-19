using Game.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Heroes
{
    class Warrior : Hero
    {
        public Warrior(int healthPoints, int attackPoints, int armorPoints) : base(healthPoints, attackPoints, armorPoints)
        {
        }
    }
}
