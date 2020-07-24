using Game.Heroes;
using Game.InputOutput;
using System;
using System.Threading;

namespace Game
{
    class GameEngine
    {
        private Hero firstHero;
        private Hero secondHero;
        private int rounds;
        private IIOEngine iOEngine;

        public GameEngine(IIOEngine iOEngine, Hero firstHero, Hero secondHero)
        {
            this.firstHero = firstHero;
            this.secondHero = secondHero;
            this.rounds = 0;
            this.iOEngine = iOEngine;
        }

        public void StartGame()
        {
            while (true)
            {
                PrintRounds();

                this.firstHero.Attack(this.secondHero);

                if (this.secondHero.HealthPoints <= 0)
                {
                    iOEngine.WriteLine($"{this.firstHero.GetType().Name} wins");
                    return;
                }

                this.secondHero.Attack(this.firstHero);

                if (this.firstHero.HealthPoints <= 0)
                {
                    iOEngine.WriteLine($"{this.secondHero.GetType().Name} wins");
                    return;
                }

                iOEngine.WriteLine(this.firstHero.ToString());
                iOEngine.WriteLine(this.secondHero.ToString());
            }
        }

        private void PrintRounds()
        {
            if (rounds == 0)
            {
                iOEngine.WriteLine("1");
                Thread.Sleep(1000);

                iOEngine.WriteLine("2");
                Thread.Sleep(1000);

                iOEngine.WriteLine("3");
                Thread.Sleep(1000);

                iOEngine.WriteLine("FIGHT");
                Thread.Sleep(1000);
            }

            rounds++;
            iOEngine.WriteLine($"Round: {rounds}");
        }
    }
}
