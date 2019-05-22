using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Launcher.src.StartupParameters
{
    class Parameters
    {
        public static void CheckParameters()
        {
            var args = Environment.GetCommandLineArgs();

            
                UnzipAddonParameter(args.Where(c=>c.StartsWith("--ExtractAddon")).FirstOrDefault());
            
        }
        private static void UnzipAddonParameter(string Parameter)
        {
            string AddonArchive = Regex.Replace(Parameter, "--ExtractAddon--", string.Empty);
            AddonArchive = Regex.Replace(AddonArchive, "--(.*)", string.Empty);
           // AddonArchive=System.Environment.GetFolderPath(Environment.SpecialFolder.)

            string Expansion = Regex.Replace(Parameter, "--ExtractAddon--(.*?)--", string.Empty);
            //Core.ZipFileManager.Extract();
        }
        
    }
}
