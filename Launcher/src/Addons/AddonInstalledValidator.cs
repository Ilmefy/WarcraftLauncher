using System.Linq;

namespace Launcher.src.Addons
{
    class AddonInstalledValidator
    {
        public static bool IsAddonInstalled(Addon Addon,Game.Game game )
        {
            var DirectoriesInAddonDirectory = System.IO.Directory.GetFiles($"{game.GameDirectory}//Interface//AddOns");
            if (DirectoriesInAddonDirectory.Contains(Addon.Name))
                return true;
            return false;
        }
    }
}
