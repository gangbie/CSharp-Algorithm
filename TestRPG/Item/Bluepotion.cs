using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class BluePotion : Item
    {
        private int point = 3;

        public BluePotion()
        {
            name = "파란포션";
            description = $"플레이어의 공격력을 {point} 증가시킵니다.";
            weight = 3;
        }
        public override void Use()
        {
            Console.WriteLine($"블루포션을 사용하여 플레이어의 공격력을 {point} 증가시킵니다.");
            Thread.Sleep(1000);
            Data.player.GetPower(point);
            Console.WriteLine($"플레이어의 공격력이 {Data.player.AP}이 되었습니다.");
            Thread.Sleep(1000);
        }
    }
}
