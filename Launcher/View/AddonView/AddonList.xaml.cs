using Launcher.src.Addons;
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
        public AddonList()
        {
            InitializeComponent();
        }
        List<Addon> CurrentlyAddedAddons = new List<Addon>();
        private void ScrollViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {

        }
        public void AddAddonControls(List<src.Addons.Addon> Addons)
        {
            var AddonsToAddAfterExceptionCurrentlyAddedAddons = Addons.Except(AddonGlobals.AddonList).ToList();
            foreach(var addon in AddonsToAddAfterExceptionCurrentlyAddedAddons)
            {
                AddonContainer.Dispatcher.Invoke(() => AddonContainer.Children.Add(Dispatcher.Invoke(() => new AddonControl(addon))));
            }
        }
    }
}
