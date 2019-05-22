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
                MainWindow.Instance.AddonList.ShowAddonsForCategory(CurrentlySelectedCategoryButton.AddonCategory);
            else
                MainWindow.Instance.AddonList.ShowAddonsForCategory(AddonCategories.Categories.All);
            
        }


    }
}
