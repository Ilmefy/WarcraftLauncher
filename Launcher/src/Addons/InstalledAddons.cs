using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Addons
{
    class InstalledAddons
    {
        /// <summary>
        /// Returns Installed Addons for specific game
        /// </summary>
        /// <param name="Game"></param>
        public static void UpdateInstalledAddons(ref Game.Game Game)
        {
            string AddonsDirectoryPath = $"{Game.GameDirectory}\\Inteface\\AddOns";
            var DirectoriesInAddonsDirectory = System.IO.Directory.GetFiles(AddonsDirectoryPath);
            List<Addon> InstalledAddonList = new List<Addon>();
            foreach(string DirectoryName in DirectoriesInAddonsDirectory)
            {
                Addon addon= (AddonGlobals.AddonList.Where(c => c.Name == DirectoryName).FirstOrDefault());
                if (!Game.InstalledAddonsList.Contains(addon))
                    Game.InstalledAddonsList.Add(addon);
            }
            
        }
    }
}
