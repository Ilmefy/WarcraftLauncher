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
            Addon.Download();
        }
        /// <summary>
        /// Occurs when Mouse enters on Addon download button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddonDownloadIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            Circle.Visibility = Visibility.Visible;
            Icon.Fill = new SolidColorBrush(Colors.Black);
        }

        /// <summary>
        /// Occurs when Mouse leaves Addon download button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddonDownloadIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            Circle.Visibility = Visibility.Hidden;
            Icon.Fill = new SolidColorBrush(Color.FromRgb(45, 203, 112));
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
        }
        /// <summary>
        /// Occurs when Right click on AddonControl and choose zoom picture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
