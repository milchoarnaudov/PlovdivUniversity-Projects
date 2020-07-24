using Game.Heroes;
using Game.InputOutput;
using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var knight = new Knight(100, 20, 100);
            var warrior = new Warrior(100, 10, 100);
            var bulgarian = new BulgarianWarrior(100, 11, 100);
            var byzantine = new Byzantine(100, 20, 100);

            // Removed the dependency to the console with Dependency Injection
            GameEngine engine = new GameEngine(new ConsoleIO(), bulgarian, byzantine);
            engine.StartGame();
        }
    }
}
