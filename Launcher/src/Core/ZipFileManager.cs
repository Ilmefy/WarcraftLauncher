using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using Ionic.Zip;

namespace Launcher.src.Core
{
    public static class ZipFileManager
    {
        /// <summary>
        /// Extracts file to specific path, then deleting file
        /// </summary>
        /// <param name="ZipFilePath"></param>
        /// <param name="PathToExtract"></param>
        public static void Extract(string ZipFilePath, string PathToExtract, bool OverwriteOldFiles, View.AddonView.AddonControl addonControlSender)
        {
            try
            {
                if (OverwriteOldFiles)
                    ExtractWithOverwriting(ZipFilePath, PathToExtract);
                else
                    ExtractWithoutOverwriting(ZipFilePath, PathToExtract);
                FileManager.DeleteFile(ZipFilePath);
                addonControlSender.DownloadingCompleted();
            }
            catch (Exception e)
            {
                addonControlSender.DownloadingFailed();
                string error = e.ToString();
                throw;
            }

        }
        /// <summary>
        /// Extracts archive and overwrites old files
        /// </summary>
        /// <param name="ZipFilePath"></param>
        /// <param name="PathToExtract"></param>
        private static void ExtractWithOverwriting(string ZipFilePath, string PathToExtract)
        {
                using (var zipFile = Ionic.Zip.ZipFile.Read(ZipFilePath))
                {
                    foreach(ZipEntry zipEntry in zipFile)
                    {
                        zipEntry.Extract(PathToExtract, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
        }
        /// <summary>
        /// Extracts archive without overwriting
        /// </summary>
        /// <param name="ZipFilePath"></param>
        /// <param name="PathToExtract"></param>
        private static void ExtractWithoutOverwriting(string ZipFilePath, string PathToExtract)
        {
            System.IO.Compression.ZipFile.ExtractToDirectory(ZipFilePath, PathToExtract);
        }

    }
}
