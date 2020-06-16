using Game.Models.Common;
using System;
using System.Threading;

namespace Game
{
    class GameEngine
    {
        private Hero firstHero;
        private Hero secondHero;
        private int rounds;

        public GameEngine(Hero firstHero, Hero secondHero)
        {
            this.firstHero = firstHero;
            this.secondHero = secondHero;
            this.rounds = 0;
        }

        public void StartGame()
        {
            while (true)
            {
                PrintRounds();

                this.firstHero.Attack(this.secondHero);

                if (this.secondHero.HealthPoints <= 0)
                {
                    Console.WriteLine($"{this.firstHero.GetType().Name} wins");
                    return;
                }

                this.secondHero.Attack(this.firstHero);

                if (this.firstHero.HealthPoints <= 0)
                {
                    Console.WriteLine($"{this.secondHero.GetType().Name} wins");
                    return;
                }

                Console.WriteLine(this.firstHero);
                Console.WriteLine(this.secondHero);
            }
        }

        private void PrintRounds()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (rounds == 0)
            {
                Console.WriteLine(1);
                Thread.Sleep(1000);
                Console.Clear();

                Console.WriteLine(2);
                Thread.Sleep(1000);
                Console.Clear();

                Console.WriteLine(3);
                Thread.Sleep(1000);
                Console.Clear();

                Console.WriteLine("FIGHT");
                Thread.Sleep(1000);
                Console.Clear();
            }

            rounds++;
            Console.WriteLine($"Round: {rounds}");
            Console.ResetColor();
        }
    }
}
