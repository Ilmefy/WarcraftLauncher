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
using Launcher.src.Game;

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
                ac.MouseWheel += Ac_MouseWheel;
                ac.Margin = new Thickness(0, 20, 20, 0);

                ViewAddonGlobalControlsList.AddonControlList.Add(ac);
                AddonGlobals.AddonQueue.Remove(addon);
            }
        }

        private void Ac_MouseWheel(object sender, MouseWheelEventArgs e)
        {
     
            if (ScrollViewer.VerticalOffset < ScrollViewer.ScrollableHeight)
                return;
            var CurrentAddonCount = AddonContainer.Children.Count;
            if (SearchBarTextBox.Text != "Search" && !string.IsNullOrEmpty(SearchBarTextBox.Text))
            {
                List<Addon> addonsByName = AddonGlobals.AddonQueue.Where(c => c.Name.ContainsWithComparer(SearchBarTextBox.Text)).ToList();
                addonsByName = addonsByName.Take(AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL).ToList();
                MainWindow.Instance.AddonList.AddAddonControls(addonsByName);
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
                GenerateMissingAddons((AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL - items));
            }

        }
        private List<Addon> GenerateMissingAddons(AddonCategories.Categories Category, int items)
        {
            return AddonGlobals.AddonQueue.Where(c => c.Category == Category).Where(c => c.Build == GameGlobals.SelectedGame.Build).Take(items).ToList();
        }
        private List<Addon> GenerateMissingAddons(string Phrase, AddonCategories.Categories Category, int items)
        {
            return  AddonGlobals.AddonQueue.Where(c => c.Name.ContainsWithComparer(Phrase)).Where(c => c.Category == Category).Where(c=>c.Build==GameGlobals.SelectedGame.Build).Take(items).ToList();
        }
        private List<Addon> GenerateMissingAddons(int items)
        {
            
            return AddonGlobals.AddonQueue.Take(items).Where(c => c.Build == GameGlobals.SelectedGame.Build).ToList();
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
            int counter = 0;
            foreach(AddonControl ac in ViewAddonGlobalControlsList.AddonControlList)
            {
                if (ac.Addon.Name.ContainsWithComparer(phrase))
                {
                    ac.Visibility = Visibility.Visible;
                    counter++;
                }
                else
                    ac.Visibility = Visibility.Collapsed;
            }
            if (counter < AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL)
            {

                if (AddonGlobals.CurrentlySelectedCategoryButton != null)
                    GenerateMissingAddons(AddonGlobals.CurrentlySelectedCategoryButton.AddonCategory, (AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL - counter));
                else
                    GenerateMissingAddons((AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL - counter));
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

        private void CategoryScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }
        /// <summary>
        /// Occurs while scrolling addons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (ScrollViewer.VerticalOffset < ScrollViewer.ScrollableHeight)
                return;
            var CurrentAddonCount = AddonContainer.Children.Count;
            List<Addon> addons = new List<Addon>();
            if (SearchBarTextBox.Text != "Search" && !string.IsNullOrEmpty(SearchBarTextBox.Text))
            {
                if (AddonGlobals.CurrentlySelectedCategoryButton != null)
                    addons = AddonGlobals.GetAddonsFromQueueWithParameter(SearchBarTextBox.Text, AddonGlobals.CurrentlySelectedCategoryButton.AddonCategory);
                else
                    addons = AddonGlobals.GetAddonsFromQueueWithParameter(SearchBarTextBox.Text);
                
            }
            else
                addons = AddonGlobals.AddonQueue.Take(AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL).ToList();
            MainWindow.Instance.AddonList.AddAddonControls(addons);
        }
    }
}
