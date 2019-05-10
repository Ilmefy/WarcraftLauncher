using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Core
{
    public class GameBuild
    {
        [Flags]
        public enum Build
        {
            None=0x1,
            Vanilla_1_12_1=0x2,
            TheBurningCrusade_2_4_3=0x4,
            WrathOfTheLichKing_3_3_5=0x8,
            Cataclysm_4_3_4=0x10,
            Mists_Of_Pandaria_5_4_8=0x20,
            Warlords_Of_Draenor_6_2_4=0x40,
        }
    }
}
