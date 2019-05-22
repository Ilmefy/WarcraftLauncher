using Launcher.src.Addons;
using Launcher.src.Core;
using Launcher.src.Game;
using Launcher.src.StartupParameters;
using Launcher.View.AddonView;
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

namespace Launcher
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            var args = Environment.GetCommandLineArgs();
            if(args.Length>1)
            {
                Parameters.CheckParameters();
            }

            Style s = new Style();
            s.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
            TabControl.ItemContainerStyle = s;
            #region Used to create simple addoncontrol
            //Addon a = new Addon() { Name = "Sunwell", Build = GameBuild.Build.WrathOfTheLichKing_3_3_5, Category=AddonCategories.Categories.Archeology };
            //Addon b = new Addon() { Name = "Sunwell", Build = GameBuild.Build.WrathOfTheLichKing_3_3_5, Category=AddonCategories.Categories.PvP };
            //List<Addon> addons = new List<Addon>();
            //addons.Add(a);
            //addons.Add(b);
            
            //System.IO.File.WriteAllText(@"C:\Users\Kirialaa\Desktop\addoniki.txt", Newtonsoft.Json.JsonConvert.SerializeObject(addons));
            //Game g = new Game() { Build = GameBuild.Build.WrathOfTheLichKing_3_3_5 };
            //GameGlobals.SelectedGame = g;
            //AddonGlobals.AddonQueue.Add(a);
            //AddonControl ac = new AddonControl(a);
            //MainWindow.Instance.AddonList.AddAddonControls(AddonGlobals.AddonQueue);
            #endregion
            //var xd= AddonGlobals.ReturnAddonForCreatingAddonControl(true);
            Initializer.InitializeApplication();
            //var Launcher = GameDataGatherer.GetGameVersion(@"D:\World of Warcraft 3.3.5a (no install)");
            //var addonlist = src.Addons.AddonInitializer.Initialize();
            //Addon a = new Addon() { Name = "GearScore", DownloadUrl = "https://wow.curseforge.com/projects/big-wigs/files/2708418/download" };
            //a.Download();

            //  src.Core.ZipFileManager.Extract(@"C:\Users\Kirialaa\Downloads\ButtonFacade-r333.zip", @"C:\Users\Kirialaa\Downloads",true);
        }
        private void xd()
        {
            string s = "";
        }
        private void TopMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ClickCount == 2 && e.LeftButton == MouseButtonState.Pressed)
            //{
            //    //MaximizeButton_MouseDown(sender, e);
            //}
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
