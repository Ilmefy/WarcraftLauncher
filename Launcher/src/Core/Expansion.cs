using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Core
{
    public class Expansion
    {
        [Flags]
        public enum Expansions
        {
            None=0x1,
            Vanilla=0x2,
            TheBurningCrusade=0x4,
            WrathOfTheLichKing=0x8,
            Cataclysm=0x10,
            MistsOfPandaria=0x20,
            WarlordsOfDraenor=0x40,
            Legion=0x80,
            BattleForAzeroth=0x100
        }
    }
}
