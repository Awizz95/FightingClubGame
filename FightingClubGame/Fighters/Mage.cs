using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingClubGame.Fighters
{
    public class Mage: BaseFighter
    {
        public Mage(string name = "Пользовательское имя") : base(name, "Высший маг", "Концентрация - Ничто не способно вывести мага из равновесия. Маг на секунду концентрируется и пускает в противника огненный шар на 1-60 урона.", 2, 3, 5)
        {

        }
        public override int UseUltimateAbility()
        {
            int totalDamage = random.Next(1, 61);
            Console.WriteLine($"{Name} на секунду концентрируется и пускает в противника огненный шар на {totalDamage} урона!");
            return totalDamage;
        }
    }
}
