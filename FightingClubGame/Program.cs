using FightingClubGame;
using FightingClubGame.Fighters;
class Program
{
    static void Main(string[] args)
    {
        PrintMenu();
    }

    static void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine($"Игра \"Бойцовский клуб\". Выберите пункт меню:\n");
        Console.WriteLine("Напишите 1, чтобы начать игру");
        Console.WriteLine("Напишите 2, чтобы посмотреть правила");
        Console.WriteLine("Напишите 3, чтобы выйти из игры");

        string userChoice = Console.ReadLine();

        if (userChoice == "1")
        {
            Game game = new Game();
            game.StartGame();
        }

        if (userChoice == "2")
        {
            ShowRules();
        }

        if (userChoice == "3")
        {
            return;
        }

            PrintMenu();
    }

    private static void ShowRules()
    {
        Console.Clear();
        Console.WriteLine($"У каждого бойца есть три характеристики - сила, ловкость и выносливость.\n" +
            $"Сила влияет на наносимый урон, ловкость влияет на шанс увернуться от удара противника, выносливость влияет на количество очкой жизней. Также у каждого бойца есть особое умение, которое он использует в бою." +
            $"Перед началом боя игроки выбирают себе бойцов и распеределяют {Constants.pointsNumber} очков умений среди трех характеристик, тем самым влияя на те или иные показатели бойца:\n" +
            $"+1 силы = +{Constants.damageMultiplier} урона, +1 ловкости = +{Constants.dodgeMultiplier}% увернуться от удара, +1 живучести = +{Constants.hpMultiplier} HP.\n" +
            $"Бой состоит из раундов. В каждом раунде бойцы наносят друг другу прямые повреждения и один раз используют особое умение. Количество раундов зависит от очков жизней бойцов. Как только у кого-нибудь из бойцов заканчиваются жизни, бой останавливается.");
        Console.WriteLine(new Warrior());
        Console.WriteLine(new Dodger());
        Console.WriteLine(new Mage());
        Console.SetCursorPosition(0, 0);
        Console.ReadLine();
    }
}