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

namespace Launcher.View.TopBar
{
    /// <summary>
    /// Logika interakcji dla klasy TopMenu.xaml
    /// </summary>
    public partial class TopMenu : UserControl
    {
        public TopMenu()
        {
            InitializeComponent();
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush ContainerCurrentBackround =(SolidColorBrush)MainWindow.Instance.TopBarColor.Background;
            (sender as Label).Background = UIColorConverter.Light(ContainerCurrentBackround);
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Label).Background = new SolidColorBrush(Colors.Transparent);
        }

        private void AddonsButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.Instance.TabControl.SelectedIndex = 1;
        }
    }
}
