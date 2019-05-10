using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Game
{
    class GameFileSearcher
    {
        public static string GetGamePath(string Path)
        {
            var FilesInDirectory = System.IO.Directory.GetFiles(Path).ToList();
            return FilesInDirectory.Where(c => c.EndsWith("WoW.exe") || c.EndsWith("Wow.exe") || c.EndsWith("Wow-64.exe")).FirstOrDefault();
           
        }
    }
}
