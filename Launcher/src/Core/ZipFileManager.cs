using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
namespace Launcher.src.Core
{
    class ZipFileManager
    {
        /// <summary>
        /// Extracts file to specific path, then deleting file
        /// </summary>
        /// <param name="ZipFilePath"></param>
        /// <param name="PathToExtract"></param>
        public static void Extract(string ZipFilePath, string PathToExtract, bool OverwriteOldFiles)
        {
            if (OverwriteOldFiles)
                ExtractWithOverwriting(ZipFilePath, PathToExtract);
            else
                ExtractWithoutOverwriting(ZipFilePath, PathToExtract);
            FileManager.DeleteFile(ZipFilePath);
        }
        /// <summary>
        /// Extracts archive and overwrites old files
        /// </summary>
        /// <param name="ZipFilePath"></param>
        /// <param name="PathToExtract"></param>
        private static void ExtractWithOverwriting(string ZipFilePath, string PathToExtract)
        {
            ZipArchive zipFile = ZipFile.OpenRead(ZipFilePath);
            foreach(ZipArchiveEntry entry in zipFile.Entries)
            {
                string EntryName = $"{PathToExtract}\\{entry.FullName} " ;
                entry.ExtractToFile(EntryName, true);
            }
        }
        /// <summary>
        /// Extracts archive without overwriting
        /// </summary>
        /// <param name="ZipFilePath"></param>
        /// <param name="PathToExtract"></param>
        private static void ExtractWithoutOverwriting(string ZipFilePath, string PathToExtract)
        {
            ZipFile.ExtractToDirectory(ZipFilePath, PathToExtract);
        }
    }
}
