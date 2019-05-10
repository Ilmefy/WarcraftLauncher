using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Core
{
    class PathVerificator
    {
        /// <summary>
        /// Checks if path leads to executable file
        /// </summary>
        /// <param name="GamePath"></param>
        /// <returns></returns>
        public static bool IsPathAFile(string Path)
        {
            if (Path.EndsWith(".exe"))
                return true;
            return false;
        }
    }
}
