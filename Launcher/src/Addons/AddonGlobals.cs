using Launcher.src.Core;
using Launcher.View.AddonView.CategoryList;
using System.Collections.Generic;
using System.Linq;

namespace Launcher.src.Addons
{
    static class AddonGlobals
    {
         public static List<Addon> AddonList = new List<Addon>();
        /// <summary>
        /// Mainly for generating addons, to not generate few times same addon
        /// </summary>
        public static List<Addon> AddonQueue = new List<Addon>();
        
        private static CategoryButton _currentlySelectedCategoryButton;

        public static CategoryButton CurrentlySelectedCategoryButton
        {
            get { return _currentlySelectedCategoryButton; }
            set { _currentlySelectedCategoryButton = value; OnAddonCategoryChange(); }
        }
        private static void OnAddonCategoryChange()
        {
            if (CurrentlySelectedCategoryButton != null)
            {
                MainWindow.Instance.AddonList.ShowAddonsForCategory(CurrentlySelectedCategoryButton.AddonCategory);
                CurrentlySelectedCategoryButton.Active = true;
            }
                
            else
                MainWindow.Instance.AddonList.ShowAddonsForCategory(AddonCategories.Categories.All);
            
        }
        /// <summary>
        /// Returns addon list from AddonQueue
        /// </summary>
        /// <param name="Phrase"></param>
        /// <returns></returns>
        public static List<Addon> GetAddonsFromQueueWithParameter(string Phrase)
        {
            return AddonQueue.Where(c => c.Name.ContainsWithComparer(Phrase)).ToList();
        }
        public static List<Addon> GetAddonsFromQueueWithParameter(string Phrase, AddonCategories.Categories addonCategory)
        {
            return GetAddonsFromQueueWithParameter(Phrase).Where(c => c.Category == addonCategory).ToList();
        }
        public static List<Addon> GetAddonsFromQueueWithParameter(string Phrase, AddonCategories.Categories addonCategory, GameBuild.Build gameBuild)
        {
            return GetAddonsFromQueueWithParameter(Phrase, addonCategory).Where(c => c.Build == gameBuild).ToList();
        }
        public static List<Addon> GetAddonsFromQueueWithParameter(string Phrase, GameBuild.Build gameBuild)
        {
            return GetAddonsFromQueueWithParameter(Phrase).Where(c => c.Build == gameBuild).ToList();
        }
    }
}
