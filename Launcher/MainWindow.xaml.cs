using Launcher.src.Addons;
using Launcher.src.Game;
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

namespace Launcher
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var Launcher = GameDataGatherer.GetGameVersion(@"D:\World of Warcraft 3.3.5a (no install)");
            var addonlist = src.Addons.AddonInitializer.Initialize();
            Addon a = new Addon() { Name = "GearScore", DownloadUrl = "https://wow.curseforge.com/projects/big-wigs/files/2708418/download" };
            a.Download();
          //  src.Core.ZipFileManager.Extract(@"C:\Users\Kirialaa\Downloads\ButtonFacade-r333.zip", @"C:\Users\Kirialaa\Downloads",true);
        }
    }
}
