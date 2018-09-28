using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covua.AppResource
{
    public partial class AppPaths
    {
        private static string ApplicationFolder
        {
            get { return Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf(@"\") + 1); }
        }
        private static string SetupFolderPath
        {
            get { return ApplicationFolder + @"Setting\"; }
        }

        private static string ProfileFolderPath
        {
            get{return SetupFolderPath + @"Profile\"; }
        }

        public static string SaveFolderPath
        {
            get{return ApplicationFolder + @"Save\";}
        }

        public static string GetSaveFilePath(string Filename)
        {
            return SaveFolderPath + Filename;
        }

        public static string GetSettingFilePath(string Filename)
        {
            return SetupFolderPath + Filename;
        }

        public static string GetProfileFilePath(string Filename)
        {
            return ProfileFolderPath + Filename;
        }

    }
    
}
