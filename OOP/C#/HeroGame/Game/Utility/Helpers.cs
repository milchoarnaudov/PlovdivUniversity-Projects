using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Utility
{
    public static class Helpers
    {
        public static bool DetermineChance(int chancePercentage)
        {
            Random rand = new Random();

            if(rand.Next(0, 100) <= chancePercentage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
