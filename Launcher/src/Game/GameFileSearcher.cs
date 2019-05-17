using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Game
{
    class GameFileSearcher
    {
        /// <summary>
        /// Searches game launcher file in specified directory
        /// </summary>
        /// <param name="Directory"></param>
        /// <returns></returns>
        public static string GetGamePath(string Directory)
        {
            var FilesInDirectory = System.IO.Directory.GetFiles(Directory).ToList();
            return FilesInDirectory.Where(c => c.EndsWith("WoW.exe") || c.EndsWith("Wow.exe") || c.EndsWith("Wow-64.exe")).FirstOrDefault();
           
        }
    }
}
