using Launcher.View.AddonView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Addons
{
    public class Addon:ICloneable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Core.GameBuild.Build Build { get; set; }
        public AddonCategories.Categories Category { get; set; }
        public Core.GameBuild.Build InstalledForBuild { get; set; }
        public string DownloadUrl { get; set; }
        public string ImageUrl { get; set; }
        /// <summary>
        /// Initializes downloading addon
        /// </summary>
        public void Download(AddonControl addonControlSender)
        {
            using (WebClient client = new WebClient())
            {
                if (string.IsNullOrEmpty(DownloadUrl))
                {
                    (addonControlSender as View.AddonView.AddonControl).DownloadingFailed();
                    return;
                }
                    
                string TemporaryPathForDownloadFile = $"{System.IO.Path.GetTempPath()}\\{Name}.zip";
                client.DownloadFileCompleted += (sender, e) => Download_Completed(sender, e, addonControlSender);
                client.DownloadProgressChanged += Download_ProgressChanged;
                var uri = new Uri(DownloadUrl);

                client.DownloadFileAsync(uri, TemporaryPathForDownloadFile);
            }
        }
        public List<Enum> GetCategoryFlags()
        {
            List<Enum> categories = new List<Enum>();
            foreach(Enum e in Enum.GetValues(typeof(AddonCategories.Categories)))
            {
                if (Category.HasFlag(e))
                    categories.Add(e);

            }
            return categories;
        }
        public bool HasBuild()
        {
            if (Build.HasFlag(Game.GameGlobals.SelectedGame.Build))
                return true;
            return false;
        }
        private void Download_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
        }
        /// <summary>
        /// Extracts File after download is completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="FileName"></param>
        private void Download_Completed(object sender, System.ComponentModel.AsyncCompletedEventArgs e, View.AddonView.AddonControl addonControlSender)
        {
            string AddonArchiveTemporaryPath = $"{System.IO.Path.GetTempPath()}\\{Name}.zip";
            Core.ZipFileManager.Extract(AddonArchiveTemporaryPath, @"C:\World of Warcraft 3.3.5a (no install)\Interface\AddOns", true, addonControlSender);
            

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
