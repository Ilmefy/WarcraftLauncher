using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Core
{
    class Initializer
    {
        /// <summary>
        /// Initializes all data
        /// </summary>
        public static void InitializeApplication()
        {
            Addons.AddonGlobals.AddonList= Addons.AddonInitializer.Initialize();
        }
    }
}
