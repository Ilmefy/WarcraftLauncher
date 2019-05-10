using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Addons
{
    public class Addon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Core.GameBuild.Build Build { get; set; }
        public AddonCategories Category { get; set; }
        public Core.GameBuild.Build InstalledForBuild { get; set; }
        public string DownloadUrl { get; set; }
        public string ImageUrl { get; set; }
        /// <summary>
        /// Initializes downloading addon
        /// </summary>
        public void Download()
        {
            using (WebClient client = new WebClient())
            {
                string TemporaryPathForDownloadFile = $"{System.IO.Path.GetTempPath()}\\{Name}.zip";
                client.DownloadFileCompleted += Download_Completed;
                client.DownloadProgressChanged += Download_ProgressChanged;
                var uri = new Uri(DownloadUrl);

                client.DownloadFileAsync(uri, TemporaryPathForDownloadFile);
            }
        }

        private void Download_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
        }
        /// <summary>
        /// Extracts File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="FileName"></param>
        private void Download_Completed(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            string AddonArchiveTemporaryPath = $"{System.IO.Path.GetTempPath()}\\{Name}.zip";
            Core.ZipFileManager.Extract(AddonArchiveTemporaryPath, "", true);
            
        }
    }
}
