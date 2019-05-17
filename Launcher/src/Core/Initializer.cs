using Launcher.src.Addons;
using Launcher.View.AddonView.CategoryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Core
{
    class Initializer
    {
        /// <summary>
        /// Initializes all data
        /// </summary>
        public static void InitializeApplication()
        {
            //Brak bazy danych
            //Addons.AddonGlobals.AddonList= Addons.AddonInitializer.Initialize();
            
            InitializeCategoryButtonsForAddons();

        }
        /// <summary>
        /// Creates and adds Buttons of categories in addon list
        /// </summary>
        private static void InitializeCategoryButtonsForAddons()
        {
            foreach (Enum e in Enum.GetValues(typeof(AddonCategories.Categories)))
            {
                CategoryButton cb = new CategoryButton() { AddonCategory = (AddonCategories.Categories)e };
                cb.Margin = new System.Windows.Thickness(10,5,10,0);
                
                cb.Container.Opacity = 0.7d;
                MainWindow.Instance.AddonList.AddCategories(cb);
                //MainWindow.Instance.AddonList.CategoryStackPanel.Children.Add(cb);
            }
        }
    }
}
