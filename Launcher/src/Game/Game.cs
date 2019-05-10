using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Launcher.src.Game
{
    class Game
    {
        public string GameDirectory { get; set; }
        public string GameLauncherPath { get; set; }
        public Core.GameBuild.Build Build { get; set; }
        public ObservableCollection<Addons.Addon> InstalledAddonsList = new ObservableCollection<Addons.Addon>();
        
        public Game()
        {
            InstalledAddonsList.CollectionChanged += InstalledAddonsList_CollectionChanged;
        }

        /// <summary>
        /// Updates Addon Installed property in AddonControl 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstalledAddonsList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var AddedItems = e.NewItems;
            foreach(Addons.Addon addon in AddedItems)
            {
                View.ViewAddonGlobalControlsList.AddonControlList.Where(c => c.Addon.Name == addon.Name && c.Addon.Build == addon.Build).FirstOrDefault().AddonInstalled = true;
            }
        }
    }
}
