using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Core
{
    class FileManager
    {
        public static void DeleteFile(string FilePath)
        {
            System.IO.File.Delete(FilePath);
        }
    }
}
