using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Core
{
    class FileManager
    {
        /// <summary>
        /// Deletes The specified file
        /// </summary>
        /// <param name="FilePath"></param>
        public static void DeleteFile(string FilePath)
        { 
            System.IO.File.Delete(FilePath);
        }
    }
}
