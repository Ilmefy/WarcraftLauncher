using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Addons
{
    class AddonInitializer
    {
        static string ADDON_FILE_PATH = @"C:\Users\Kirialaa\Desktop\NoweZKategoriami.json";
        /// <summary>
        /// Returns list of addons from json file
        /// </summary>
        /// <returns></returns>
        public static List<Addon> Initialize()
        {
            string Data = System.IO.File.ReadAllText(ADDON_FILE_PATH);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Addon>>(Data);
        }

        static void CreateAddonList()
        {
            try
            {
                foreach(Addon addon in AddonGlobals.AddonList)
                {
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
