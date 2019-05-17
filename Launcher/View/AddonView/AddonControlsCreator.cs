using Launcher.src.Addons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.View.AddonView
{
    class AddonControlsCreator
    {
        /// <summary>
        /// Creates AddonControls and adds to AddonListControl
        /// </summary>
        /// <param name="AddonList"></param>
        [Obsolete("Trzeba oskryptowac dodawanie")]
        public static void CreateAddonControls(List<Addon> AddonList)
        {
            foreach(Addon addon in AddonList)
            {
                AddonControl ac = new AddonControl(addon);
//                MainWindow.Instance
            }
        }
    }
}
