using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Addons
{
    class GetAddons
    {
        /// <summary>
        /// Returns addon and deletes it from AddonQueue
        /// </summary>
        /// <param name="ForActualBuild"></param>
        /// <returns></returns>
        public static Addon ReturnAddonForCreatingAddonControl(bool ForActualBuild)
        {
            if (AddonQueueIsEmptyOrNull())
                return null;
            Addon addonToReturn = new Addon();
            Addon temp = new Addon();
            if (ForActualBuild)
                temp = AddonGlobals.AddonQueue.Where(c => c.Build.HasFlag(Game.GameGlobals.SelectedGame.Build)).FirstOrDefault();
            else
                temp = AddonGlobals.AddonQueue[0];
            addonToReturn = (Addon)temp.Clone();
            AddonGlobals.AddonQueue.Remove(temp);
            return addonToReturn;
        }
        private static bool AddonQueueIsEmptyOrNull()
        {
            if (AddonGlobals.AddonQueue.Count == 0)
                return true;
            return false;
        }
        /// <summary>
        /// Returns addon and deletes it from AddonQueue
        /// </summary>
        /// <param name="Category"></param>
        /// <param name="ForActualBuild"></param>
        /// <returns></returns>
        public static Addon ReturnAddonForCreatingAddonControl(System.Enum Category, bool ForActualBuild)
        {
            if (AddonQueueIsEmptyOrNull())
                return null;
            Addon addonToReturn = new Addon();
            Addon temp = new Addon();
            if (ForActualBuild)
                temp = AddonGlobals.AddonQueue.Where(c => c.Build.HasFlag(Game.GameGlobals.SelectedGame.Build)).Where(x => x.Category.HasFlag(Category)).FirstOrDefault();
            else
                temp = AddonGlobals.AddonQueue[0];
            addonToReturn = (Addon)temp.Clone();
            AddonGlobals.AddonQueue.Remove(temp);
            return addonToReturn;
        }
    }
}
