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
using Launcher.src.Core;
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
                ac.Margin = new Thickness(0, 20, 20, 0);

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



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = (sender as TextBox).Text;
            if (string.IsNullOrEmpty(text) || text=="Search")
                return;
            ShowAddonsNameContains(text);

        }
        public void ShowAddonsNameContains(string phrase)
        {
            //&& c.HasBuild()
            List<Addon> addonsContainsPhrase = AddonGlobals.AddonList.Where(c => c.Name.ContainsWithComparer(phrase)).ToList();
            //foreach (Addon addon in addonsContainsPhrase)
            //{
            //    ViewAddonGlobalControlsList.AddonControlList.Where(c => c.Addon.Name.Equals( addon.Name)).FirstOrDefault().Visibility = Visibility.Visible;
            //}
            foreach (Addon addon in addonsContainsPhrase)
            {
                ViewAddonGlobalControlsList.AddonControlList.Where(c => c.Addon != addon).FirstOrDefault().Visibility = Visibility.Collapsed;
            }
            int addonContainsPhraseCount = addonsContainsPhrase.Count;
            if(addonContainsPhraseCount<AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL)
            {
                List<Addon> addonsToGenerate = new List<Addon>();
                int HowMuchNeed = AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL - addonContainsPhraseCount;
                    addonsToGenerate = AddonGlobals.AddonQueue.Where(c => c.Name.ContainsWithComparer(phrase)).Take(HowMuchNeed).ToList();
                AddAddonControls(addonsToGenerate);
            }
            
        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as TextBox).Text = "";
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = "";
        }
        public UIElementCollection ReturnCategoryControls()
        {
            return CategoryStackPanel.Children;
        }
    }
}
