using FightingClubGame.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingClubGame
{
    public class Game
    {
        private Random random;
        private GameStatus gameStatus;
        private BaseFighter player1;
        private BaseFighter player2; 

        public Game()
        {
            random = new Random();
            gameStatus = GameStatus.NextRound;
        }
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Создание первого игрока\n");
            player1 = CreateFighter();
            Console.Clear();
            Console.WriteLine("Создание второго игрока\n");
            player2 = CreateFighter();
            Console.Clear();
            StartFight();
        }

        private void StartFight()
        {
            for (int i = 3; i < 0; i--)
            {
                Console.Clear();
                Console.WriteLine($"{i}...");
                Console.ReadLine();
            }

            int round = 1;

            while (gameStatus == GameStatus.NextRound)
            {
                Console.Clear();
                Console.WriteLine($"РАУНД {round}\n");

                CalculateDamage(player1, player2);
                CalculateDamage(player2, player1);

                Console.WriteLine();
                Console.WriteLine("ИГРОК 1");
                Console.WriteLine(player1);
                Console.WriteLine();
                Console.WriteLine("ИГРОК 2");
                Console.WriteLine(player2);

                Console.ReadLine();
                round++;
            }
            Console.WriteLine("БОЙ ОКОНЧЕН!");
            Console.ReadLine();
        }

        private void CalculateDamage(BaseFighter agressor, BaseFighter victim)
        {
            if (victim.DodgeChance > random.Next(1, 101))
            {
                Console.WriteLine($"{agressor.Name} хотел ударить, но противник увернулся от удара!");
            }
            else
            {
                victim.HP -= agressor.Kick();
                victim.HP -= agressor.UseUltimateAbility();
            }
        }

        private BaseFighter CreateFighter()
        {
            BaseFighter fighter;
            int points = 5;

            Console.WriteLine("Выберите имя бойца:");
            string name = Console.ReadLine();

            Console.WriteLine("\nВыберите класс героя:\n1. Воин\n2. Ловкач\n3. Маг\n");
            string fighterType = Console.ReadLine();

            switch (fighterType)
            {
                case "1":
                    fighter = new Warrior(name);
                    break;
                case "2":
                    fighter = new Dodger(name);
                    break;
                default:
                    fighter = new Mage(name);
                    break;
            }

            while (points > 0)
            {
                Console.Clear();
                Console.WriteLine(fighter);
                Console.WriteLine("Распределите очки умений среди характеристик персонажа:");
                Console.WriteLine("+1 Силы:      +{0} к урону", Constants.damageMultiplier);
                Console.WriteLine("+1 Ловкости:  +{0}% увернуться от атаки", Constants.dodgeMultiplier);
                Console.WriteLine("+1 Живучести: +{0} HP", Constants.hpMultiplier);
                Console.WriteLine();
                Console.WriteLine("Осталось очков умений: {0}", points);
                Console.WriteLine("1: +1 Силы");
                Console.WriteLine("2: +1 Ловкости");
                Console.WriteLine("3: +1 Живучести");
                switch (Console.ReadLine())
                {
                    case "1":
                        fighter.Strength++;
                        break;
                    case "2":
                        fighter.Agility++;
                        break;
                    default:
                        fighter.Vitality++;
                        break;
                }

                points--;
            }

            fighter.isDead += () => gameStatus = GameStatus.Stopped;
            return fighter;
        }
    }
}
