using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FightingClubGame.Fighters
{
    public class Warrior : BaseFighter
    {
        public Warrior(string name = "Пользовательское имя") : base(name, "Воин с мечом и щитом", "Ярость - Боль делает воина только сильнее. После удара воин впадает в ярость и трижды бьет противника щитом. Урон каждого удара равен показателю силы", 5, 0, 5)
        {

        }

        public override int UseUltimateAbility()
        {
            int totalDamage = Strength * 3;
            Console.WriteLine($"{Name} впадает в ярость! Он трижды бьет щитом и наносит {totalDamage} урона!");
            return totalDamage;
        }
    }
}
