using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingClubGame.Fighters
{
    public class Dodger : BaseFighter
    {
        public Dodger(string name = "Пользовательское имя") : base(name, "Ловкач", "Ловкость рук - Есть 25% шанс запутать противника и незаметно ударить противника второй рукой. Такой удар считается критическим (х3 урона). ", 3, 4, 3)
        {

        }

        public override int UseUltimateAbility()
        {
            int chance = random.Next(1, 101);

            if (chance <= 25)
            {
                int totalDamage = Damage * 3;
                Console.WriteLine($"{Name} изловчился и ударил второй рукой! Этот удар оказался критическим и нанес {totalDamage} урона!");
                return totalDamage;
            }
            Console.WriteLine($"{Name} попытался незаметно ударить второй рукой, но противник это заметил и увернулся!");
            return 0;
        }
    }
}
