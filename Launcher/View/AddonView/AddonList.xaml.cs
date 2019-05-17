using Launcher.src.Addons;
using Launcher.View.AddonView.CategoryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launcher.View.AddonView
{
    /// <summary>
    /// Logika interakcji dla klasy AddonList.xaml
    /// </summary>
    public partial class AddonList : UserControl
    {
        private src.Addons.AddonCategories.Categories _Categories;

        public src.Addons.AddonCategories.Categories Categories
        {
            get { return _Categories; }
            set { _Categories = value; }
        }

        public void AddCategories(CategoryButton obj)
        {
            CategoryStackPanel.Children.Add(obj);
        }
        public AddonList()
        {
            InitializeComponent();
        }
        List<Addon> CurrentlyAddedAddons = new List<Addon>();
        /// <summary>
        /// Script for loading more addons, works exactly the same as google graphics. Loads when scroll to bottom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {

        }
        /// <summary>
        /// Creates AddonControl and adds to AddonList
        /// </summary>
        /// <param name="Addons"></param>
        public void AddAddonControls(List<src.Addons.Addon> Addons)
        {
            var AddonsToAddAfterExceptionCurrentlyAddedAddons = Addons.Except(AddonGlobals.AddonList).ToList();
            foreach (var addon in AddonsToAddAfterExceptionCurrentlyAddedAddons)
            {
                AddonControl ac = new AddonControl(addon);
                AddonContainer.Dispatcher.Invoke(() => AddonContainer.Children.Add(Dispatcher.Invoke(() =>ac)));
                ViewAddonGlobalControlsList.AddonControlList.Add(ac);
            }
        }
        /// <summary>
        /// Shows addons for specific category
        /// </summary>
        /// <param name="Category"></param>
        public void ShowAddonsForCategory(AddonCategories.Categories Category)
        {
            int items = 0;
            foreach (AddonControl ac in ViewAddonGlobalControlsList.AddonControlList)
            {
                if (ac.Addon.Category.HasFlag(Category))
                {
                    ac.Visibility = Visibility.Visible;
                    items++;
                }

                else
                    ac.Visibility = Visibility.Collapsed;
            }
            if (items < AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL)
            {

            }

        }
        private void GenerateMissingAddons(AddonCategories.Categories Category, int items)
        {
            for (int i = 0; i < (AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL - items); i++)
            {
                Addon addon = AddonGlobals.AddonQueue.Where(c => c.Category.HasFlag(Category)).Where(c => c.HasBuild()).FirstOrDefault();
                AddonControl ac = new AddonControl(AddonGlobals.AddonQueue.Where(c => c.Category.HasFlag(Category)).Where(c => c.HasBuild()).FirstOrDefault());
            }
        }


    }
}
