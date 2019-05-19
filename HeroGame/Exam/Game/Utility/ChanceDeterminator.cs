using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Utility
{
    public static class ChanceDeterminator
    {
        public static bool Determine(int chance)
        {
            Random rand = new Random();
            if(rand.Next(0, 100) <= chance)
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
