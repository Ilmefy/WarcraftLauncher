using Launcher.View.AddonView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Addons
{
    class AddonInitializer
    {
        static string ADDON_FILE_PATH = @"C:\Users\Kirialaa\Desktop\addoniki.json";
        /// <summary>
        /// Returns list of addons from json file
        /// </summary>
        /// <returns></returns>
        public static List<Addon> Initialize()
        {
            string Data = System.IO.File.ReadAllText(ADDON_FILE_PATH);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Addon>>(Data);
        }

        public static void CreateAddonList()
        {
            try
            {
                int HowMuchAddonsCreate = 0;
                if (AddonGlobals.AddonQueue.Count < AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL)
                    HowMuchAddonsCreate = AddonGlobals.AddonQueue.Count;
                else
                    HowMuchAddonsCreate = AddonConstants.HOW_MUCH_ADDONS_SHOW_AT_SCROLL;
                List<Addon> AddonsToCreate = new List<Addon>();
                for(int i=0;i<HowMuchAddonsCreate;i++)
                {
                    AddonsToCreate.Add(AddonGlobals.AddonQueue[0]);
                    AddonGlobals.AddonQueue.RemoveAt(0);                                       
                }
                MainWindow.Instance.AddonList.AddAddonControls(AddonsToCreate);
                


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
