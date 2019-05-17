using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Game
{
    class GameDataGatherer
    {
        /// <summary>
        /// Gets version of game launcher
        /// </summary>
        /// <param name="GamePath"></param>
        public static Core.GameBuild.Build GetGameVersion(string Path)
        {
            if (Core.PathVerificator.IsPathAFile(Path))
                return ConvertFileVersionToGameBuild( FileVersionInfo.GetVersionInfo(Path));
            string GameLauncherPath = GameFileSearcher.GetGamePath(Path);
            return ConvertFileVersionToGameBuild(FileVersionInfo.GetVersionInfo(GameFileSearcher.GetGamePath(Path)));
        }
        /// <summary>
        /// Converts FileVersionInfo to GameBuild
        /// </summary>
        /// <param name="info">FileVersionInfo can be obtained from FileVersionInfo.GetVersionInfo method</param>
        /// <returns></returns>
        private static Core.GameBuild.Build ConvertFileVersionToGameBuild(FileVersionInfo info)
        {
            string BuildString = $"{info.FileMajorPart}_{info.FileMinorPart}_{info.FileBuildPart}";
            switch(BuildString)
            {
                case "1_12_1":
                    return Core.GameBuild.Build.Vanilla_1_12_1;
                case "2_4_3":
                    return Core.GameBuild.Build.TheBurningCrusade_2_4_3;
                case "3_3_5":
                    return Core.GameBuild.Build.WrathOfTheLichKing_3_3_5;
                case "4_3_4":
                    return Core.GameBuild.Build.Cataclysm_4_3_4;
                case "5_4_8":
                    return Core.GameBuild.Build.Mists_Of_Pandaria_5_4_8;
                case "6_2_4":
                    return Core.GameBuild.Build.Warlords_Of_Draenor_6_2_4;
            }
            return Core.GameBuild.Build.None;
        }

    }
}
