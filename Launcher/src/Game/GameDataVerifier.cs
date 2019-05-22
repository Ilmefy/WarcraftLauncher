using Launcher.src.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Game
{
    public static class GameDataVerifier
    {
        public  static bool IsGameInstalled(Expansion.Expansions expansion)
        {
            if (GameGlobals.InstalledGames.Count == 0)
                return false;
            if (GameGlobals.InstalledGames.Exists(c => c.Expansion == expansion))
                return true;
            return false;

        }
    }
}
