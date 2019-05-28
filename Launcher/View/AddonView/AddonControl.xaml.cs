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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Launcher.src.Addons.AddonCategories;

namespace Launcher.View.AddonView
{
    /// <summary>
    /// Logika interakcji dla klasy AddonControl.xaml
    /// </summary>
    public partial class AddonControl : UserControl
    {
        private SolidColorBrush ADDON_INSTALLED_BORDER_COLOR_BRUSH = new SolidColorBrush(Colors.Green);
        public src.Addons.Addon Addon { get; set; }
        public AddonControl(src.Addons.Addon Addon)
        {
            InitializeComponent();
            this.Addon = Addon;
            NameLabel.Content = Addon.Name;
            DescriptionTextBlock.Text = Addon.Description;
            SetCategoryIcons();
            SetBackground();
        }
        /// <summary>
        /// Sets image of addon
        /// </summary>
        private void SetBackground()
        {
            if (!string.IsNullOrEmpty(Addon.ImageUrl))
                Background.Source = new BitmapImage(new Uri(Addon.ImageUrl));
            else
                Background.Source = new BitmapImage(new Uri("/View/Icons/Backgrounds/Legion.jpg", UriKind.RelativeOrAbsolute));
            

        }
        private void SetCategoryIcons()
        {
            List<Enum> categories = Addon.GetCategoryFlags();
            foreach(Enum e in categories)
            {
                Image i = new Image();
                Uri uri = new Uri($"/View/Icons/CategoryList/Icons/{e .ToString()}.png", UriKind.Relative);
                i.Source = new BitmapImage(uri);
                i.Width = 32;
                CategoryIcons.Children.Add(i);
                i.MouseDown += CategoryIcon_MouseDown;
                i.MouseEnter += CategoryIcon_MouseEnter;
                i.MouseLeave += CategoryIcon_MouseLeave;
                i.Opacity = 0.5;
            }
        }
        private bool _AddonInstalled;

        public bool AddonInstalled
        {
            get { return _AddonInstalled; }
            set { _AddonInstalled = value; OnAddonInstalledChange(); }
        }
        /// <summary>
        /// Updates AddonControl look
        /// </summary>
        private void OnAddonInstalledChange()
        {
            if (AddonInstalled)
                Border.BorderBrush = ADDON_INSTALLED_BORDER_COLOR_BRUSH;
            else
                Border.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }
        /// <summary>
        /// Occurs when Download button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddonDownloadIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Addon.Download(this);
        }
        /// <summary>
        /// Occurs when Mouse enters on Addon download button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddonDownloadIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            Circle.Visibility = Visibility.Visible;
            DownloadIcon.Fill = new SolidColorBrush(Colors.Black);
        }
        public void DownloadingFailed()
        {
            Border.BorderBrush = new SolidColorBrush(Colors.Red);
            Border.Visibility = Visibility.Visible;
            InstallingStateLabel.Content = "Error has occured while installing.";
            InstallingStateLabel.Visibility = Visibility.Visible;
            InstallingStateLabel.Foreground = new SolidColorBrush(Colors.Red);
            DownloadGrid.Visibility = Visibility.Hidden;
        }
        public void DownloadingCompleted()
        {
            Border.BorderBrush = new SolidColorBrush(Colors.Green);
            InstallingStateLabel.Visibility = Visibility.Visible;
            InstallingStateLabel.Content = "Addon has been properly installed";
            InstallingStateLabel.Foreground = new SolidColorBrush(Colors.Green);
            DownloadGrid.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Occurs when Mouse leaves Addon download button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddonDownloadIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            Circle.Visibility = Visibility.Hidden;
            DownloadIcon.Fill = new SolidColorBrush(Color.FromRgb(45, 203, 112));
        }

        /// <summary>
        /// Occurs when Mouse enters on AddonControl. Is used for Showing addon description and download button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Container_MouseEnter(object sender, MouseEventArgs e)
        {
            TopProgressBar.Visibility = Visibility.Hidden;
          
            BottomProgressBar.Visibility = Visibility.Visible;
            ThicknessAnimation ta = new ThicknessAnimation
            {
                From = Container.Margin,
                To = new Thickness(0),
                Duration = TimeSpan.FromSeconds(0.2)
            };
            Container.BeginAnimation(MarginProperty, ta);
            ta.From = CategoryIconScrollViewer.Margin;
            CategoryIconScrollViewer.BeginAnimation(MarginProperty, ta);
        }

        /// <summary>
        /// Occurs when Mouse Leaves AddonControl. Used for hiding addon description and download button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Container_MouseLeave(object sender, MouseEventArgs e)
        {
            TopProgressBar.Visibility = Visibility.Visible;
            BottomProgressBar.Visibility = Visibility.Hidden;
            ThicknessAnimation ta = new ThicknessAnimation
            {
                From = Container.Margin,
                To = new Thickness(0, 190, 0, 0),
                Duration = TimeSpan.FromSeconds(0.2)
            };
            Container.BeginAnimation(MarginProperty, ta);

            ta.From = CategoryIconScrollViewer.Margin;
            ta.To = new Thickness(0, 0, 70, 0);
            CategoryIconScrollViewer.BeginAnimation(MarginProperty, ta);
        }
        /// <summary>
        /// Occurs when Right click on AddonControl and choose zoom picture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.AddonImageZoom.Image.Source = Background.Source;
            MainWindow.Instance.AddonImageZoom.AddonNameLabel.Content = Addon.Name;
            MainWindow.Instance.AddonImageZoom.Visibility = Visibility.Visible;
            
        }

        private void CategoryIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image).Opacity = 0.5d;
        }

        private void CategoryIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Image).Opacity = 1.0d;
        }

        private void CategoryIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            src.Addons.AddonCategories.Categories category = src.Addons.AddonCategories.GetCategoryByCategoryIcon((sender as Image).Source.ToString());
            var CategoryControlsList = MainWindow.Instance.AddonList.ReturnCategoryControls().Cast<CategoryList.CategoryButton>().ToList();
            if (src.Addons.AddonGlobals.CurrentlySelectedCategoryButton != null)
                src.Addons.AddonGlobals.CurrentlySelectedCategoryButton.Active = false;
            src.Addons.AddonGlobals.CurrentlySelectedCategoryButton = CategoryControlsList.Where(c => c.AddonCategory == category).FirstOrDefault();
        }
    }
}
