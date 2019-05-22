using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Game
{
    class GameGlobals
    {
        public static Game SelectedGame { get; set; }
        public static List<Game> InstalledGames = new List<Game>();
    }
}
